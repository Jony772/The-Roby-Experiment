using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
[SerializeField] float mouseSensitivity, sprintSpeed, walkSpeed, jumpForce, smoothTime;
[SerializeField] GameObject cameraHolder;

float verticalLookrotation;
bool grounded; 
Vector3 smoothMoveVelocity; 
Vector3 moveAmount; 

Rigidbody rb;


void Awake()
{
    rb = GetComponent<Rigidbody>();
}

void Update()
{
    Look();
    Move();
    Jump();
    


}




void Look()
{
    transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X") * mouseSensitivity);
    verticalLookrotation += Input.GetAxisRaw("Mouse Y") * mouseSensitivity;
    verticalLookrotation = Mathf.Clamp(verticalLookrotation, -90f, 90f);

    cameraHolder.transform.localEulerAngles = Vector3.left * verticalLookrotation;
}

void Move()
{
    Vector3 moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

    moveAmount = Vector3.SmoothDamp(moveAmount, moveDir * (Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed), ref smoothMoveVelocity, smoothTime);
}

void Jump()
{
    if(Input.GetKeyDown(KeyCode.Space) && grounded)
    {
        Debug.Log("jump");
        rb.AddForce(transform.up * jumpForce);
    }
}

public void SetGrounderState(bool _grounded)
{
    grounded = _grounded;
}

void FixedUpdate()
{
    rb.MovePosition(rb.position + transform.TransformDirection(moveAmount) * Time.fixedDeltaTime);
}

}


