using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleMery : MonoBehaviour       // Script para los coleccionables (nota: falta implementaci�n en el HUD)
{
    public void OnTriggerEnter2D(Collider2D other)           // Si colisiona con otro collider
    {
        if (other.CompareTag("Player") && !other.isTrigger)  // Y este tiene el tag player, y adem�s este collider tiene un trigger (revisar)
        {
            Destroy(gameObject);                             // Destruir
        }
    }
}
