using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemyMery : MonoBehaviour           // Script para en enemigo que patrulla de punto A a punto B
{
    private Rigidbody2D rb;        // Mantenemos el RB para colisi�n
    private Animator anim;         // Animaciones
    private SpriteRenderer sr;     // Permite flipear
    private EnemyMery enemy;        // Como los GO tienen el script podria ser privado tal vez

    public Transform Point1;       // Puntos de patrulla
    public Transform Point2;
    float direction = 1;           // Asegura que el enemigo puede moverse sin un target seteando una direcci�n

    private Transform target;      // Cambia de target cuando llega al contrario
    private Vector2 change;        // Vector2 controla el valor de los axis

    private void Start()
    {
        target = Point1;                              // Empieza persiguiendo el punto 1

        anim = GetComponent<Animator>();              // Componentes de animaci�n y sprite
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        enemy = GetComponent<EnemyMery>();

        anim.SetFloat("moveX", 0);                    // Float que controla si el objeto se est� moviendo en el axis x
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
    void Flip()                                               // De nuevo a lo mejor estos podrian ser privates
    {
        if (transform.position.x < target.position.x)           // Si la posici�n en x del RB es menor a la posici�n en x del target
        {
            sr.flipX = true;                                   // El sprite se flipea
        }
        else if (transform.position.x > target.position.x)     // Pero si la posici�n en x del RB es mayor a la posici�n en x del target
        {
            sr.flipX = false;                                  // El sprite no se flipea
        }
    }

    void MoveEnemy()
    {
        direction = direction - enemy.speed * Time.deltaTime;                                                         // Asegura que siempre hay una direcci�n incluso sin target
        transform.position = Vector2.MoveTowards(transform.position, target.position, enemy.speed * Time.deltaTime);  // Mueve el enemigo hacia el target al speed marcado

        if (transform.position == Point1.position)                                                              // Cuando el transform.position es igual al point1
        {
            target = Point2;                                                                                    // cambia el target
        }
        else if (transform.position == Point2.position)                                                        // pero si....
        {
            target = Point1;
        }
    }

    void Animation()                                       
    {
        if (change != new Vector2(0, 0))                    // Si el vector2 que estamos controlando no es igual a un nuevo vector2    
        {
            anim.SetFloat("SpeedMovement", enemy.speed);          // El SM se setea en funci�n del speed asignado
            anim.SetBool("isMoving", true);                 // isMoving se setea en verdadero
            anim.SetFloat("moveX", change.x);               // moveX cambia en funci�n a change.x
        }
        else                                                // De lo contrario
        {
            anim.SetBool("isMoving", false);                // isMoving se setea en falso 
        }
    }
}

