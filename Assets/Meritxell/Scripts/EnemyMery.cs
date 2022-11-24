using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMery : MonoBehaviour
{
    public int health = 100;    // Salud total

    public GameObject deathEffect;
    
    public void TakeDamage (int damage)    // void que llama el int de da�o
    {
        health -= damage;     // restar el da�o a la salud

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
