using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMery : MonoBehaviour
{
    public int health = 100;    // Salud total
    private Rigidbody2D rb;

    private AnimationEnemyMery ae;

    private void Start()
    {
        ae = GetComponent<AnimationEnemyMery>();
    }
    private void Update()
    {
        transform.position = new Vector2(ae.xMovement * ae.speed, rb.velocity.y);  
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
