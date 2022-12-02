using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponMery : MonoBehaviour
{ 
    public Transform firePoint;         // coge el spawn
    public Transform firePointL;
    public GameObject bulletPrefab;     // coge la bala
    public Animator anim;               // para el bool
    public SpriteRenderer sr;

    public float fireRate = 0.5f;       // no se puede disparar hasta que...
    public float nextFire = 0.0f;
    public bool isFlipped;

    void Start()

    {
        anim = GetComponent<Animator>();    // Las variables deben asignarse a los componentes

    }

    void Update () 
    {
           if (Input.GetButton("Fire1") && Time.time > nextFire)      // input asignado 
           {
                nextFire = Time.time + fireRate;                      // el fire rate detiene el siguiente de salir hasta que haya pasado el tiempo
                Shoot();
           }

           void Shoot()                // los puntos de origen
           {
                if (sr.flipX == true)
                {
    
                Instantiate(bulletPrefab, firePointL.position, firePointL.rotation);
                }
                else
                {
                Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                }
           }         
    }
}

