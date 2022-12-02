using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEnemyMery : MonoBehaviour         // Script que controla el "arma" del jugador
{
    public Transform firePoint;         // Coge los spawn (como el sprite gira con un flip en el sr, no se altera al girar; por tanto hace falta un spawn en cada lado)
    public Transform firePointL;
    public GameObject bulletPrefab;     // coge el prefab de la Bala

    private Animator anim;               // El animator se coge para detectar el bool de muerte          
    private SpriteRenderer sr;           // El Srpite se necesita para detectar si se ha flipeado

    public float fireRate = 0.5f;       // no se puede disparar hasta que...
    public float nextFire = 0.0f;       // Resetea el tiempo desde el disparo anterior
    public bool isFlipped;              // Mirar si necesito esto

    private void Start()                        
    {
        anim = GetComponent<Animator>();             // Las variables deben asignarse a los componentes
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()              
    {
        if (anim.GetBool("isAttacking") == true)
        {
             if (Time.time > nextFire && anim.GetBool("Dead") == false)         // Si el bool Dead es verdadero entonces deja de disparar 
             {
                  nextFire = Time.time + fireRate;                               // No se pede disparar hasta que ha pasado el firerate
                  Shoot();                                                       // Llama al disparo
             }

             void Shoot()                                // Disparo
             {
                  if (sr.flipX == false)                 // Si el sr no está flipeado, la bala se instancia en el firePointL
                  {

                       Instantiate(bulletPrefab, firePointL.position, firePointL.rotation);
                  }
                  else                                  // Si no, la bala se instancia en el firePoint
                  {
                       Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                  }
             }
        }
    }
}
