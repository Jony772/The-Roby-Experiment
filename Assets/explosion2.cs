using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion2 : MonoBehaviour
{

   // public Transform explosionPrefab;
    //public Rigidbody Rigid;
    public float force = 950;
    // Start is called before the first frame update
    void Start()
    {
        // GetComponent<Collider>().attachedRigidbody.AddForce(0, 22222, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    void OnCollisionEnter(Collision collision)
    {
         Debug.Log("Collision");
         
         Vector3 dir = collision.contacts[0].point - transform.position;
         dir = -dir.normalized;
         //GetComponent<Rigidbody>().AddForce(dir*force);
         GetComponent<Collider>().attachedRigidbody.AddForce(dir * force);




       // ContactPoint contact = collision.contacts[0];
       // Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contact.normal);
        //Vector3 position = contact.point;
      //  Instantiate(explosionPrefab, position, rotation);
       // Destroy(gameObject);
    }
}
