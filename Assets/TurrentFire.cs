using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurrentFire : MonoBehaviour
{
    /*public GameObject bullet;
    public float bulletSpeed;
    public Vector3 exit;*/
    public Rigidbody projectile;
    public Transform gunEnd;
    
    void Start()
    {
        InvokeRepeating("fire", 2.0f, 2.0f);
    }

    void Update()
    {
        
        //Instantiate(bullet, exit, Quaternion.identity);

    }


    public void fire()
    {
        Rigidbody projectileInstance;
        projectileInstance =  Instantiate(projectile, gunEnd.position, gunEnd.rotation * Quaternion.Euler (-90f, 0f, 0f)) as Rigidbody;
        projectileInstance.AddForce(gunEnd.forward * 5000f);
    }

   /* public void fire(GameObject _bullet, float _bulletSpeed, Vector3 _exit)
    {
        _bullet = bullet;
        _bulletSpeed = bulletSpeed;
        _exit = exit;
        Instantiate(_bullet, _exit, Quaternion.identity);
    }*/
}
