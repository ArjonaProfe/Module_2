using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMery : MonoBehaviour           // Script general para todos los enemigos
{
    public int health;                          // Puntos de salud
    private Animator anim;                       // Animator para las animaciones de da�o y muerte
    private Rigidbody2D rb;                      // Para la interaci�n con otros scripts funcione bien
    private Collider2D col;                      // Para que enemigos derrotados no tengan colisi�n

    public float speed = 5f;                    // Velocidad del enemigo

    private void Start()
    {
        anim = GetComponent<Animator>();         // Coger componentes
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }
    public void TakeDamage()                     // Se llama este script desde Bullet
    {
        if (health > 0)                          // Si los puntos de salud son mayor que zero
        {
        DamageAndCureMery.damage = 1;           // Se coge el int de DamageandCure
        health -= DamageAndCureMery.damage;      // restar el da�o a la salud
        anim.SetBool("isHurt", true);            // Se setea el bool isHurt a verdaderp
        Invoke("SetBoolBack", 0.5f);             // Se llama la funci�n tras el tiempo establecido
        }
        else                                     // si baja de 0
        {
            Die();                               // Se llama la funci�n Die
        }
    }

    void Die()                                   
    {
        anim.SetBool("Dead", true);                               // Setea el bool Dead a true
        speed = 0f;                                               // El enemigo dejar� de moverse al morir
        rb.constraints = RigidbodyConstraints2D.FreezePosition;   // Esto evita que el enemigo caiga del escenario al perder la colisi�n
        Destroy(this.col);                                        // Destruye el collider
        Destroy(this.gameObject, 2f);                             // Destruye el enemigo despu�s del tiempo establecido 
    }
    private void SetBoolBack()
    {
        anim.SetBool("isHurt", false);           // Vuelve a poner el bool en falso
    }
}
