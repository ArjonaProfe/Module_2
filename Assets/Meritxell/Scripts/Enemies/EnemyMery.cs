using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMery : MonoBehaviour           // Script general para todos los enemigos
{
    public int health;                          // Puntos de salud
    public Animator anim;                       // Animator para las animaciones de daño y muerte
    public Rigidbody2D rb;                      // Para la interación con otros scripts funcione bien

    public float speed = 5f;                    // Velocidad del enemigo

    private void Start()
    {
        anim = GetComponent<Animator>();         // Coger componentes
        rb = GetComponent<Rigidbody2D>();
      
    }
    public void TakeDamage()                     // Se llama este script desde Bullet
    {
        if (health > 0)                          // Si los puntos de salud son mayor que zero
        {
        DamageAndCureMery.damage = 40;           // Se coge el int de DamageandCure
        health -= DamageAndCureMery.damage;      // restar el daño a la salud
        anim.SetBool("isHurt", true);            // Se setea el bool isHurt a verdaderp
        Invoke("SetBoolBack", 0.5f);             // Se llama la función tras el tiempo establecido
        }
        else                                     // si baja de 0
        {
            Die();                               // Se llama la función Die
        }
    }

    void Die()                                   
    {
        anim.SetBool("Dead", true);              // Setea el bool Dead a true
        speed = 0f;                             // coge la velocidad
        Destroy(this.gameObject, 1.5f);
    }
    private void SetBoolBack()
    {
        anim.SetBool("isHurt", false);
    }
}
