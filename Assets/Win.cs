using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using System.IO;


public class Win : MonoBehaviour
{
    PhotonView PV;
    
    public static string nameofWinner;
    void Start()
    {
        PV = GetComponent<PhotonView>();
    }

    void Update()
    {
        
    }
    [PunRPC]
    void OnCollisionEnter(Collision collision)
    {
        nameofWinner = PlayerPrefs.GetString("username");
        winScene();
    }




    public void winScene()
    {
        //Debug.Log("winnnnn");
        SceneManager.LoadScene("Win");
    }
}
