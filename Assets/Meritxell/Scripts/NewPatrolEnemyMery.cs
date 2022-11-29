using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPatrolEnemyMery : MonoBehaviour
{
    public int health = 100;
    private Rigidbody2D rb;
    private Animator anim;

    public float speed;
    public Transform Point1;   // puntos de patrulla
    public Transform Point2;


    private Transform target;     // cambia de target cuando llega al contrario
    private Vector2 change;

    private NewAnimationEnemyMery ae;

    private void Start()
    {
        target = Point1;       // Empieza en el contrario
        ae = GetComponent<NewAnimationEnemyMery>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);  // mueve el enemigo hacia el target al speed marcado

        if (transform.position == Point1.position)       // Cuando el transform.position es igual al point1
        {
            target = Point2;                             // cambia el target
        }
        else if (transform.position == Point2.position)  // pero si encaja con el dos
        {
            target = Point1;
        }
       
        change = Vector2.zero;                    // asigna los valores x0, y0
        change.x = speed;                   // según xMovement se modifica cuando cuando change.x lo hace, lo que se basa en el speed

        Animation();
    }
    void Animation()                                       // si el vector2 no es igual a zero, cambia el valor de xMovement y de isMoving, cambiando la animación 
    {
        if (change != new Vector2(0, 0))
        {
            anim.SetFloat("xMovement", change.x);
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }
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
