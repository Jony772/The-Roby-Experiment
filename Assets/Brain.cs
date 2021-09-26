using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain : MonoBehaviour
{
    public Material oldM;
    public Material newM;
    Renderer rend;
    
    void Start()
    {
        
        rend = GetComponent<Renderer>();
        rend.sharedMaterial = oldM;
        if (transform.parent.parent.parent.tag == "Active")
        {
            rend.sharedMaterial = newM;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
