using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemyMery : MonoBehaviour
{
    public float speed = 5f;          // Velocidad de la bala
    public int damage = 40;           // Daño que causa la bala

    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = transform.right * speed;        // Mueve el objeto hacia delante
    }
    void OnTriggerEnter2D(Collider2D hitInfo)         // Cuando entra en un collider
    {
        PlayerHealthMery player = hitInfo.GetComponent<PlayerHealthMery>();
        
        if (hitInfo.CompareTag("Player"))     // Si tocase partes del escenario
        {
            if (player != null)
            {
               
            }
            Destroy(gameObject);
        }
        else if (hitInfo.CompareTag("Ground"))     // Si tocase partes del escenario
        {
            Destroy(gameObject);
        }
    }
}
