using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesRise : MonoBehaviour
{
    public Transform target; 
    public Transform target2;
    public float t;
    private int check = 1;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("up", 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(check==1)
        {
        Vector3 a = transform.position;
        Vector3 b = target.position;
        transform.position = Vector3.Lerp(a,b,t);
        Invoke("up", 5.0f);

        }
        else
        {
        Vector3 a = transform.position;
        Vector3 b = target2.position;
        transform.position = Vector3.Lerp(a,b,t);
        Invoke("down", 5.0f);
        }
        
        


    }
    public void down()
    {
       /* Vector3 a = transform.position;
        Vector3 b = target2.position;
        transform.position = Vector3.Lerp(a,b,t);
        Invoke("up", 5.0f);*/
        check = 1;
    }

    public void up()
    {
        check = 0;
    }
}
