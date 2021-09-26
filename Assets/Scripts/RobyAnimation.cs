using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobyAnimation : MonoBehaviour
{
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
       /* if (Input.GetKeyDown(KeyCode.W))
            anim.SetBool("moving", true);
        if (Input.GetKeyDown(KeyCode.S))
            anim.SetBool("moving", true);
        if (Input.GetKeyDown(KeyCode.A))
            anim.SetBool("moving", true);
        if (Input.GetKeyDown(KeyCode.D))
            anim.SetBool("moving", true);

        if (Input.GetKeyUp(KeyCode.W))
            anim.SetBool("moving", false);
        if (Input.GetKeyUp(KeyCode.S))
            anim.SetBool("moving", false);
        if (Input.GetKeyUp(KeyCode.A))
            anim.SetBool("moving", false);
        if (Input.GetKeyUp(KeyCode.D))
            anim.SetBool("moving", false);
        */

        if(ThirdPersonMovment.isMoving == true)
        {
            anim.SetBool("moving", true);
        }
        else
        {
            anim.SetBool("moving", false);
        }




        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("jump", true);
            Invoke("jumpOff", 2);
        }

        if (ThirdPersonMovment.isMoving == false && anim.GetBool("jump") == false)
        {
            anim.SetBool("stand", true);
        }



        /*if(ThirdPersonMovment.speed > 0)
        {
            anim.SetBool("moving", true);
        }*/
    }

    public void jumpOff()
    {
        anim.SetBool("jump", false);
    }
}
