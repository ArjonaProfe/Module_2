using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItemMery : MonoBehaviour          // Los items de cura
{
    public int healthPoints;
    public int cure;

    public bool Partial;        // Si el item es de tipo parcial o full
    public bool Full;

    public void Start()
    {
        healthPoints = HealthCounterMery.healthPoints;        // Coge los puntos de vida y el valor de curación
        cure = DamageAndCureMery.cure = 1;
    }
 
    void OnTriggerStay2D(Collider2D other)
    {
        if (Partial == true)
        {
            if (other.CompareTag("Player") && Input.GetButtonDown("Fire2") && HealthCounterMery.healthPoints! < 5)            // Si la vida es menor de 5, añade un punto
            {
                HealthCounterMery.healthPoints = HealthCounterMery.healthPoints + cure;
                Destroy(gameObject);
            }
        }
             
        if (Full == true)
        {
             if (other.CompareTag("Player") && Input.GetButtonDown("Fire2") && HealthCounterMery.healthPoints != 5)           // Si la vida no es cinco, la vuelve cinco
             {
                    HealthCounterMery.healthPoints = 5;
                    Destroy(gameObject);
             }  
        }
    }
}

