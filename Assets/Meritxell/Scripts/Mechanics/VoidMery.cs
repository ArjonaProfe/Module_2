using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidMery : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)           // Si colisiona con otro collider
    {
        if (other.CompareTag("Player") && !other.isTrigger)  // Y este tiene el tag player, y además este collider tiene un trigger (revisar)
        {
            PlayerLivesMery.Death();
            HealthCounterMery.healthPoints = HealthCounterMery.healthPoints = 0;
        }
    }
}
