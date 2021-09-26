using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using Photon.Pun;
using System.IO;

public class RagDoll : MonoBehaviour
{
    [SerializeField] private Animator animator = null;
    private Rigidbody[] ragdollBodies;
    private Collider[] ragdollColliders;
    public GameObject disableMove;
    public GameObject Roby;
    public GameObject RobyRunning;
    public int robyNum = 1;
    public string robyName = "1";
    public int currentRoby;
    public TextMeshPro numText;
    public GameObject disableCharacter;
    public GameObject disableBoxCollider;
    GameObject controller;
    PhotonView PV;
    PlayerManager playerManager;
    //public Rigidbody rigidbody2;

    public GameObject cam;
    
    //public Collider robyCollider;
    //public GameObject obstacle;
    public Rigidbody theOneInTheHip;
    public Collider collider1;
    //GameObject varGameObject = GameObject.Find("ThirdPersonMovment");



    void Awake()
    {
        /*if(GameObject.Find("1") == true)
        {
            robyName = "2";
        }*/
         PV = GetComponent<PhotonView>();
        //playerManager = PhotonView.Find((int)PV.InstantiationData[0]).GetComponent<PlayerManager>();
        robyName = robyNum.ToString();
        Roby.name = robyName;
        currentRoby = Convert.ToInt32(Roby.name);
        numText.text = "Roby " + Roby.name + ".0";
        playerManager = ThirdPersonMovment.playerManager;
        //rigidbody2 = GetComponent<Rigidbody>();

    }

    void Start()
    {

        ragdollBodies = GetComponentsInChildren<Rigidbody>();
        ragdollColliders = GetComponentsInChildren<Collider>();
        ToggleRagdoll(false);
        //Invoke("die", 5); 
        disableMove.GetComponent<ThirdPersonMovment>();
        disableCharacter.GetComponent<CharacterController>();
        //disableBoxCollider.GetComponent<BoxCollider>();
        collider1.GetComponent<Collider>();
        collider1.enabled = true;
        foreach(Collider collider in ragdollColliders)
        {
            collider.enabled = true;
        }
        theOneInTheHip.isKinematic = false;

        
       // rigidbody2.isKinematic = false;
    }

    void Update()
    {

        if(robyNum > currentRoby)
        {
            Roby.tag = "Finish";
            RobyRunning.tag = "Finish";
            disableMove.GetComponent<ThirdPersonMovment>().enabled = false;
        }

      


    }

    private void ToggleRagdoll(bool state)
    {
        //collider1.enabled = false;

        animator.enabled = !state;

        foreach(Rigidbody rb in ragdollBodies)
        {
            rb.isKinematic = !state;
        }

        foreach(Collider collider in ragdollColliders)
        {
            collider.enabled = state;
        }
    }
    [PunRPC]
    public void die()
    {
        Roby.tag = "Finish";

        Destroy(cam);
        /*robyCollider = Roby.GetComponent<BoxCollider>();
        Destroy(robyCollider);*/
        //Destroy(obstacle);
        /*Roby.tag = "Finish";
        RobyRunning.tag = "Finish";*/
        //collider1.enabled = false;
        //controller = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Roby"), Vector3.zero, Quaternion.identity, 0, new object[] {PV.ViewID});
        //Destroy(collider1);
        //ToggleRagdoll(true);
        foreach(Rigidbody rb in ragdollBodies)
        {
        rb.AddExplosionForce(107f, new Vector3(-1f, 0.5f, -1f), 5f, 0f, ForceMode.Impulse);
        }
        robyNum = robyNum + 1;
        //Instantiate(Roby, new Vector3(0, 20, 0), Quaternion.identity);
       // controller = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Roby"), Vector3.zero, Quaternion.identity, 0, new object[] {PV.ViewID});
        
        //disableCharacter.GetComponent<CharacterController>().enabled = false;
        //disableBoxCollider.GetComponent<BoxCollider>().enabled = false;
        playerManager.Die();
        
    }

    /*public void ragdollTrueTimer()
    {
        ToggleRagdoll(true);
    }*/

    /*void OnCollisionEnter(Collision collision)
    {
        ToggleRagdoll(true);
    }*/

    public void OnTriggerEnter(Collider other)  
    {
        //ragDoll.robyNum++;
        Debug.Log("Trigger");
        ragDollStart();
        //die();
    }

    public void ragDollStart()
    {
        Roby.tag = "Finish";
        robyNum = robyNum + 1;
        Destroy(collider1);
        disableCharacter.GetComponent<CharacterController>().enabled = false;
        disableBoxCollider.GetComponent<BoxCollider>().enabled = false;
        ToggleRagdoll(true);
        robyNum = robyNum + 1;
        Invoke("die",3.0f);
        Destroy(cam);

    }



    /*public void OnCollisionEnter(Collision collision)
    {
        //ragDoll.robyNum++;
        Debug.Log("Trigger");
        die();
    }*/



}
