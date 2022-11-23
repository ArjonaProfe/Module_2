using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponMery : MonoBehaviour
{ 
    public Transform firePoint;         // coge el spawn
    public GameObject bulletPrefab;     // coge la bala
    public float fireRate = 0.5f;
    public float nextFire = 0.0f;


void Update () 
    {
    if (Input.GetButton("Fire1") && Time.time > nextFire)      // input asignado 
            {
            nextFire = Time.time + fireRate;
            Shoot();
            }
    void Shoot()
            {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);     // crear el objeto en el spawn
            }  
    }
}

