using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidExpload : MonoBehaviour
{
        public Transform explosionPrefab;

         public AudioClip audioClip;
         float mass = 1.0F; // defines the character mass
         Vector3 impact = Vector3.zero;
         private CharacterController character;
         // Use this for initialization
         void Start () {
              character = GetComponent<CharacterController>();
              //GetComponent<AudioSource> ().playOnAwake = false;
               GetComponent<AudioSource>().clip = audioClip;
         }
         
         // Update is called once per frame
         void Update () {
          // apply the impact force:
           if (impact.magnitude > 99.2F) character.Move(impact * Time.deltaTime);
               // consumes the impact energy each cycle:
               impact = Vector3.Lerp(impact, Vector3.zero, 5*Time.deltaTime);
         }
         // call this function to add an impact force:
         public void AddImpact(Vector3 dir, float force){
           dir.Normalize();
           if (dir.y < 0) dir.y = -dir.y; // reflect down force on the ground
           impact += dir.normalized * force / mass;
         }

        public void OnCollisionEnter(Collision collision)      
        {
            GetComponent<AudioSource> ().Play ();
            Debug.Log("COLLIDER");
            Vector3 dir = collision.contacts[0].point - transform.position;
            dir = -dir.normalized;
            AddImpact(dir,9900);

            ContactPoint contact = collision.contacts[0];
            Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 position = contact.point;
            Instantiate(explosionPrefab, position, rotation);
            Destroy(explosionPrefab, 5.0f);
        }

}

