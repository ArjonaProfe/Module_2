using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMery : MonoBehaviour           // Script general para todos los enemigos
{
    public int health;                          // El health se cambiarà aqui según el tipo
    public Animator anim;
    public Rigidbody2D rb;

    private ChaseEnemyMery ce;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        ce = GetComponent<ChaseEnemyMery>();
    }
    public void TakeDamage()                   // Se llama este script desde Bullet
    {

        if (health > 0)
        {
        DamageAndCureMery.damage = 40;                         // Se coge el int de DamageandCure
        health -= DamageAndCureMery.damage;                    // restar el daño a la salud
        anim.SetBool("isHurt", true);
        Invoke("SetBoolBack", 0.5f);
        }
        else                         // si baja de 0, activa void die
        {
            Die();
        }
    }

    void Die()                                  // Destruye el objeto
    {
        anim.SetBool("Dead", true);
        ce.speed = 0f;
        Destroy(this.gameObject, 3f);
    }
    private void SetBoolBack()
    {
        anim.SetBool("isHurt", false);
    }
}
