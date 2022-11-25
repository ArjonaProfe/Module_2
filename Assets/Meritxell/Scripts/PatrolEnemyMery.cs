using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemyMery : MonoBehaviour
{
    public int health = 100;
    public float speed;
    private Rigidbody2D rb;
    
    public Transform Point1;   // puntos de patrulla
    public Transform Point2;

    private Transform target;     // cambia de target cuando llega al contrario

    private void Start()
    {
        target = Point1;       // Empieza en el contrario
    }

    void Update()
    {
        if (transform.position == Point1.position)       // Cuando el transform.position es igual al point1
        {
            target = Point2;                             // cambia el target
        }
        else if (transform.position == Point2.position)  // pero si encaja con el dos
        {
            target = Point1;                               
        }

        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);  // mueve el enemigo hacia el target al speed marcado
    }

    public void TakeDamage(int damage)    // void que llama el int de daño
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
