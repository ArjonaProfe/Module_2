using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleMery : MonoBehaviour       // Script para los coleccionables (nota: falta implementación en el HUD)
{
    private Collider2D col;
    private Rigidbody2D rb;

    public int collected;

    public void Start()
    {
        col = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();

        collected = CollectibleCounterMery.collected;
    }
    public void OnTriggerEnter2D(Collider2D other)           // Si colisiona con otro collider
    {
        if (other.CompareTag("Player") && !other.isTrigger)  // Y este tiene el tag player, y además este collider tiene un trigger (revisar)
        {
            CollectibleCounterMery.collected = CollectibleCounterMery.collected + 1;
            Destroy(gameObject);                             // Destruir
        }
    }
}
