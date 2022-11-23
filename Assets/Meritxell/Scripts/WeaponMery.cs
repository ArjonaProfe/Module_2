using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponMery : MonoBehaviour
{ 
    public Transform firePoint;         // coge el spawn
    public GameObject bulletPrefab;     // coge la bala

    void Update () 
    {
    if (Input.GetButtonDown("Fire1"))      // input asignado 
    {
        Shoot();
    }
    void Shoot()
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);     // crear el objeto en el spawn
        }
    }
}
