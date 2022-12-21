using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemyMery : MonoBehaviour
{
    public float speed = 5f;          // Velocidad de la bala
    public int damage = 1;           // Da�o que causa la bala

    public Rigidbody2D rb;            // El RB del objeto (probar private)

    void Start()                     // probar private
    {
        rb.velocity = transform.right * speed;        // Mueve el objeto hacia delante
    }
    private void Update()
    {
        DestroyTimer();                              // Llama la funci�n 
    }

    void OnTriggerEnter2D(Collider2D hitInfo)         // Cuando entra en un collider. Crea el parametro hitInfo
    {
        PlayerHealthMery player = hitInfo.GetComponent<PlayerHealthMery>();   // Interactua con el script al que llama player, y le asigna el hitInfo
        
        if (hitInfo.CompareTag("Player"))             // Si el collider detecta el tag player
        {
            if (player != null)                       // Y el player no es null (se encuentra la informaci�n de player)
            {
                player.PlayerDamage();                // Se activa PlayerDamage
            }
            Destroy(gameObject);                      // Luego se destruye el objeto
        }
        else if (hitInfo.CompareTag("Ground"))        // Pero si detecta el tag Ground
        {
            Destroy(gameObject);                      // Se destruye en el impacto
        }
    }
    void DestroyTimer()                 // Si ha pasado 1 unidad de tiempo y la bala no ha chocado con nada, se destruye
    {
        Destroy(gameObject, 2f);
    }

    void OnBecameInvisible()            // Destruye cuando sale de la camara
    {
        Destroy(gameObject);
    }
}
