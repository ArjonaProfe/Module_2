using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMery : MonoBehaviour
{
    public int health = 100;    // Salud total
    public float speed;         // velocidad del enemigo
    private Rigidbody2D rb;
    
    public float xMovement;

    private void Update()
    {
        transform.position = new Vector2(xMovement * speed, rb.velocity.y);  
    }
    public void TakeDamage (int damage)    // void que llama el int de daño
    {
        health -= damage;     // restar el daño a la salud

        if (health <= 0)      // si baja de 0, activa void die
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
