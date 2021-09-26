using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ManageRoby1 : MonoBehaviour
{
    public CinemachineFreeLook vcam;
    public GameObject roby;
    public Transform follow;


    void Start()
    {
        var vcam = GetComponent<CinemachineVirtualCamera>();
        

    }

    void Update()
    {
        roby = GameObject.FindGameObjectWithTag("active2");
        follow = roby.transform;
        vcam.Follow = follow;
        vcam.LookAt = follow;
    }
}
