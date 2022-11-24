using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMery : MonoBehaviour
{
    public float speed = 5f;
    public int damage = 40;

    public Rigidbody2D rb;

    void Start()                         // Se mueve hacia delante
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)         // Destruye objeto cuando choca con un collider
    {
        EnemyMery enemy = hitInfo.GetComponent<EnemyMery>();  // Coger el script de enemy
        if (enemy != null)     // si enemy no es null (encuentra un enemigo)
        {
            enemy.TakeDamage(damage);   // coge el int damage para determinar el daño
        }
        Destroy(gameObject);
    }

    void OnBecameInvisible()            // Destruye cuando sale de la camara
    {
        Destroy(gameObject);
    }
}
