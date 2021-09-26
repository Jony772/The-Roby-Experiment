using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class billboard : MonoBehaviour
{
    GameObject cam;
    GameObject cameraA;
    void Update()
    {
        if(cam == null)
            cam = GameObject.FindGameObjectWithTag("Camera A");
        if(cam == null)
            return;
        
        transform.LookAt(cam.transform);
        transform.Rotate(Vector3.up * 180);
    }
}
