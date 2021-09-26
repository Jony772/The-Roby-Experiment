using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ManageRoby : MonoBehaviour
{
    public CinemachineFreeLook vcam;
    public GameObject roby;
    public Transform follow;
    //public GameObject[] robys;


    void Start()
    {
        var vcam = GetComponent<CinemachineVirtualCamera>();      
    }

    void Update()
    {
        /*robys = GameObject.FindGameObjectsWithTag("Active");
        if(robys.Length > 1)
        robys[1].tag = "active2";*/

        roby = GameObject.FindGameObjectWithTag("Active");
        follow = roby.transform;
        vcam.Follow = follow;
        vcam.LookAt = follow;
    }
}
