using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapitaCollider_AC : MonoBehaviour
{
    // Start is called before the first frame update

    //script para colisionar las plataformas tapitas
    private void OnCollisionEnter2D (Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            Debug.Log("Salvada");           //en la consola sale el mensaje cuando suceda la colisi�n
        }
    }
  
}
