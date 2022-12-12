using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMery : MonoBehaviour           // Script de las balas que dispara el personaje
{
    public float speed = 5f;          // Velocidad de la bala
    public int damage = 1;           // Daño que causa la bala

    public Rigidbody2D rb;         

    void Start()                         
    {
        rb.velocity = transform.right * speed;        // Mueve el objeto hacia delante
    }
    private void Update()
    {
        DestroyTimer();                              // Llama la función 
    }

    void OnTriggerEnter2D(Collider2D hitInfo)         // Cuando entra en un collider
    {
        EnemyMery enemy = hitInfo.GetComponent<EnemyMery>();   // Coger el script de Enemy 

        if (hitInfo.CompareTag("Enemy"))            // Si el objeto contra el que activa el collider tiene el tag Enemy
        {
            if (enemy != null)     // Si enemy no es null (encuentra un enemigo)
            {
                enemy.TakeDamage();   // Llama el void TakeDamage de Enemy
            }
            Destroy(gameObject);          // Se destruye
        }
        else if (hitInfo.CompareTag("Ground"))     // Si tocase partes del escenario
        {
            Destroy(gameObject);         // Se destruye
        }
    }
    void DestroyTimer()                 // Si ha pasado 1 unidad de tiempo y la bala no ha chocado con nada, se destruye
    {
        Destroy(gameObject, 1f);        
    }

    void OnBecameInvisible()            // Destruye cuando sale de la camara
    {
        Destroy(gameObject);
    }
}
