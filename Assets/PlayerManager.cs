using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class PlayerManager : MonoBehaviour
{
    PhotonView PV;

    GameObject controller;

    void Awake()
    {
        PV = GetComponent<PhotonView>();
    }

    void Start()
    {
        if(PV.IsMine)
        {
            CreateController();
        }
        if(!PV.IsMine)
            return;
    }

    void CreateController()
    {
        if(!PV.IsMine)
            return;
        controller = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Roby"), new Vector3(-10.0f,-40.0f,-70.0f), Quaternion.identity, 0, new object[] {PV.ViewID});
        
    }

    public void Die()
    {
        //PhotonNetwork.Destroy(controller);
        CreateController();
    }

}
