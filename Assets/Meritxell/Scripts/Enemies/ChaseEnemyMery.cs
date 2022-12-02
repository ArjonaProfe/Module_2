using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseEnemyMery : MonoBehaviour             // Script para en enemigo que persigue al jugador
{
    private Rigidbody2D rb;        // Mantenemos el RB para colisión
    private Animator anim;         // Animaciones
    private SpriteRenderer sr;     // Permite flipear
    private EnemyMery enemy;

    public Transform target;       // Asignaremos al player
    float direction = 1;           // Asegura que el enemigo puede moverse sin un target seteando una dirección

    private Vector2 change;        // Vector2 controla el valor de los axis

    private void Start()
    {    
        anim = GetComponent<Animator>();              // Componentes de animación y sprite
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        enemy = GetComponent<EnemyMery>();

        anim.SetFloat("moveX", 0);                    // Float que controla si el objeto se está moviendo en el axis x
        anim.SetFloat("SpeedMovement", 0);            // El float que controla la velocidad
    }

    private void Update()
    {
        change = Vector2.zero;                        // Asigna los valores x0, y0 (esto es global y no local)
        change.x = transform.localPosition.x;         // Cambia el axis x

        Flip();                                       // Llama las funciones
        MoveEnemy();
        Animation();
    }

    void Flip()                                                // De nuevo a lo mejor estos podrian ser privates
    {
        if (transform.position.x < target.position.x)          // Si la posición en x del RB es menor a la posición en x del target
        {
            sr.flipX = true;                                   // El sprite se flipea
        }
        else if (transform.position.x > target.position.x)     // Pero si la posición en x del RB es mayor a la posición en x del target
        {
            sr.flipX = false;                                  // El sprite no se flipea
        }
    }

    void MoveEnemy()
    {
        direction = direction - enemy.speed * Time.deltaTime;                                                         // Asegura que siempre hay una dirección incluso sin target
        transform.position = Vector2.MoveTowards(transform.position, target.position, enemy.speed * Time.deltaTime);  // Mueve el enemigo hacia el target al speed marcado
    }

    void Animation()                                       
    {
        if (change != new Vector2(0, 0))                  // Si el vector2 que estamos controlando no es igual a un nuevo vector2   
        {
            anim.SetFloat("SpeedMovement", enemy.speed);        // El SM se setea en función del speed asignado
            anim.SetBool("isMoving", true);               // isMoving se setea en verdadero
            anim.SetFloat("moveX", change.x);             // moveX cambia en función a change.x
        }
        else                                             // De lo contrario
        {
            anim.SetBool("isMoving", false);             // isMoving se setea en falso 
        }
    }
}


