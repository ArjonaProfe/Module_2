using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItemMery : MonoBehaviour
{
    public int healthPoints;
    public int cure;

    public bool Partial;
    public bool Full;

    public void Start()
    {
        healthPoints = HealthCounterMery.healthPoints;
        cure = DamageAndCureMery.cure = 1;
    }
 
    void OnTriggerStay2D(Collider2D other)
    {
        if (Partial == true)
        {
            if (other.CompareTag("Player") && Input.GetButtonDown("Fire2") && HealthCounterMery.healthPoints! < 5)
            {
                HealthCounterMery.healthPoints = HealthCounterMery.healthPoints + cure;
                Destroy(gameObject);
            }
        }
             
        if (Full == true)
        {
             if (other.CompareTag("Player") && Input.GetButtonDown("Fire2") && HealthCounterMery.healthPoints != 5)
             {
                    HealthCounterMery.healthPoints = 5;
                    Destroy(gameObject);
             }  
        }
    }
}

