using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMery : MonoBehaviour           // Script general para todos los enemigos
{
    public int health;                          // El health se cambiarà aqui según el tipo
    public Animator anim;                      
   
    public bool isHurt;                         // No funciona???


    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void TakeDamage()                   // Se llama este script desde Bullet
    {

        DamageAndCureMery.damage = 40;                         // Se coge el int de DamageandCure
        health -= DamageAndCureMery.damage;                    // restar el daño a la salud
        isHurt = true;                                         // No funciona????
        Debug.Log("Entra");                                    // Pero este log si que entra...


        if (health <= 0)                         // si baja de 0, activa void die
        {
            Die();
        }
    }

    void Die()                                  // Destruye el objeto
    {
        anim.SetTrigger("Dead");
        Destroy(gameObject);
    }
}
