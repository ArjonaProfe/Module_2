using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponMery : MonoBehaviour  // Script que controla el "arma" del personaje
{ 
    public Transform firePoint;          // coge los puntos de spawn de las balas
    public Transform firePointL;
    public GameObject bulletPrefab;      // coge la bala
    public Animator anim;                // para el bool (Revisar, creo que al final no se usa)
    public SpriteRenderer sr;
    private PlayerMovementMery pm;

    public float fireRate = 0.5f;       // No se puede disparar hasta que...
    public float nextFire = 0.0f;       // Tiempo base de disparo

    void Start()

    {
        anim = GetComponent<Animator>();    // Las variables deben asignarse a los componentes
        pm = GetComponent<PlayerMovementMery>();
    }

    void Update () 
    {
        if(PauseManagerMery.isPaused == false && pm.isDucking == false)
        {
            if (Input.GetButton("Fire1") && Time.time > nextFire)      // input asignado. Si se pulsa el input Fire1 y el tiempo pasado en time is mayor a nextFire
            {
                nextFire = Time.time + fireRate;                      // nextFire corresponde a tiempo sumado con el fireRate
                Shoot();                                              // Llama a la función 
            }

            void Shoot()                     // Dispara
            {
                if (sr.flipX == true)       // Si el sprite está flipeado se instancia la bala desde firePointL
                {

                    Instantiate(bulletPrefab, firePointL.position, firePointL.rotation);
                }
                else                       // Si no, se instancia desde FirePoint
                {
                    Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                }
            }
        }
              
    }
}

