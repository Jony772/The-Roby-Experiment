using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;


public class ThirdPersonMovment : MonoBehaviour
{
    //public Rigidbody m_Rigidbody;
    [SerializeField]
    private float _gravity = 300.81f;
    private float _directionY;
    [SerializeField]
    private float _jumpSpeed = 3.5f;
    public GameObject roby;
    public RagDoll ragDoll;
    public GameObject robyRunning;

    public CharacterController controller;
    public static float speed = 10.0f;
    public float turnSmoothTime = 0.9f;
    float turnSmoothVelocity;
    public Transform cam;
    public static bool isMoving = false;

    PhotonView PV;
    GameObject controller2;
    public GameObject[] robys;

    public static PlayerManager playerManager;

    /*public Transform brain; // 30.7
    public Color blue = Color.blue;
    Material brainMat;*/



    void Awake () 
    {
        PV = GetComponent<PhotonView>();
        ragDoll = GetComponent<RagDoll>();
        playerManager = PhotonView.Find((int)PV.InstantiationData[0]).GetComponent<PlayerManager>();



        if (GameObject.FindWithTag("Active") == null)
        {
            roby.tag = "Active";
        }

    }


    void Start()
    {

        /*if(!PV.IsMine)   
        {
            Destroy(controller);
        }*/
        controller = GetComponent<CharacterController>();
        cam = GameObject.FindWithTag("Camera A").transform;
        robys = GameObject.FindGameObjectsWithTag("Active");
        if(robys.Length > 1)
        robys[1].tag = "active2";
        //brain = transform.Find("brain");
    }

    void Update()
    {
        if(!PV.IsMine)
        {
            roby.tag = "active2";
            return;
        }
        //playerManager = PhotonView.Find((int)PV.InstantiationData[0]).GetComponent<PlayerManager>();

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        if(direction.magnitude >= 0.1f)
        {
            isMoving = true;
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
        else
        {
            isMoving = false;
        }

         /*if (Input.GetKeyDown(KeyCode.Space))
            {
                Invoke("jumping", 0.0f);
            }*/
        
         _directionY -= _gravity * Time.deltaTime;
        direction.y = _directionY;
        controller.Move(direction * speed * Time.deltaTime);

        if(robys.Length == 1)
        {                                 //change
        robys[0].tag = "Active";
        //brain.m
        //robys[ = Color.blue;0].transform.Find("brain")   //change
        }

    }

        public void jumping()   //This is for the build up jump animation
        {
            _directionY = _jumpSpeed;
        }
     void OnCollisionEnter(Collision collision)
     {
        // ragDoll = GetComponent<RagDoll>();
        // ragDoll.die();
         //Debug.Log("collision");
     }

     void Die()
     {
         Debug.Log("die");
     }
}
