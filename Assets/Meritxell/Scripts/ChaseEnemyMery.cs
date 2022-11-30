using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseEnemyMery : EnemyMery             // Script para en enemigo que patrulla de punto A a punto B
{
    public int health = 100;       // Puntos de vida (ajustar con da�o de bullet)
    private Rigidbody2D rb;        // Mantenemos el RB para colisi�n
    private Animator anim;         // Animaciones
    private SpriteRenderer sr;     // Permite flipear

    public float speed;            // La velocidad a la que va a moverse (5 parece un buen default)
    public Transform target;           // Asignaremos al player
    float direction = 1;           // Asegura que el enemigo puede moverse sin un target seteando una direcci�n

    private Vector2 change;        // Vector2 controla el valor de los axis

    private void Start()
    {    
        anim = GetComponent<Animator>();              // Componentes de animaci�n y sprite
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        anim.SetFloat("moveX", 0);                    // Float que controla si el axis 
        anim.SetFloat("SpeedMovement", 0);            // El float que controla la direci�n (necesita ser asignado)
    }

    private void Update()
    {
        change = Vector2.zero;                        // Asigna los valores x0, y0 (esto es global y no local, pero no he encontrado soluci�n y como este enemigo tampoco va a estar nunca quieto no importa mucho)
        change.x = transform.localPosition.x;         // Cambia el axis x

        Flip();                                       // Llama las funciones. TakeDamage no cuenta porque requiere informaci�n de otros
        MoveEnemy();
        Animation();
    }

    void MoveEnemy()
    {
        direction = direction - speed * Time.deltaTime;                                                         // Asegura que siempre hay una direcci�n incluso sin target
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);  // Mueve el enemigo hacia el target al speed marcado
    }

    void Animation()                                       // si el vector2 no es igual a zero, cambia el valor de moveX y de isMoving, cambiando la animaci�n 
    {
        if (change != new Vector2(0, 0))
        {
            anim.SetFloat("SpeedMovement", speed);
            anim.SetBool("isMoving", true);
            anim.SetFloat("moveX", change.x);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }
    }

    void Flip()                                               // Si el target se encuentra a la derecha (mayor que), el sr se flipea; pero si no...
    {
        if (transform.position.x < target.position.x)
        {
            sr.flipX = true;
        }
        else if (transform.position.x > target.position.x)
        {
            sr.flipX = false;
        }
    }

    public void TakeDamage(int damage)             // void que llama el int de da�o
    {
        health -= damage;                         // restar el da�o a la salud
        anim.SetTrigger("isHurt");                // Aqui ir� la animaci�n de da�o

        if (health <= 0)                         // si baja de 0, activa void die
        {
            Die();
        }
    }

    void Die()                                  // Destruye el objeto
    {
        anim.SetTrigger("Dead");               // Aqui ir� la animaci�n de muerte 
        Destroy(gameObject);
    }
}


