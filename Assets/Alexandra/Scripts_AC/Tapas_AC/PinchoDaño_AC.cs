using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchoDaño_AC : MonoBehaviour
{
    [SerializeField] private float tiempoEntreDaño;
    private float tiempoSiguienteDaño;
    private float TomarDaño;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag ("Player"))
        {
            tiempoSiguienteDaño -= Time.deltaTime;
            if (tiempoSiguienteDaño <= 0)
            { /*
                 other.GetComponent <AceitunaLife_AC>().TomarDaño(1);    //indicamos el daño que va a recibir nuestro Player
                 tiempoSiguienteDaño = tiempoEntreDaño;
                */
            }
                
        }
    }
}
