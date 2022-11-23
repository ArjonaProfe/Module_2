using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementGerard : MonoBehaviour
{

    public Transform rayOrigin;                // aquí se asigna el punto desde el que se lanza el raycast.
    private Rigidbody2D rb;                   // hago privado la asiganción de RigidBody2D a rb.

    public float xspeed;                    // hago publico el parametro xspeed para controlar la velocidad en X.
    public float jump;                     // aquí se asigna la potencia de "jump".
    public bool isGrounded;               // aquí se comnprueba si el personaje está tocando el suelo.

    private float xMovement;                   // aquí se guarda el valor del Axis X que mueve al personaje.
    private AnimationManagerGerard am;        // aquí se referencia el script "AnimationManagerGerard".



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();                // le añado del rigidbody2D al objeto que pongamos en "rb".
    }


    private void Update()
    {
        PlayerMovement();                                                       // se llama a la función 'PlayerMovement'
        IsGrounded();                                                          // se llama a la función 'IsGrounded'

        if (Input.GetButtonDown("Jump") && isGrounded == true)               // si se pulsa el botón 'Jump' y la variable 'isGrounded' es true
        {
            Jump();                                                        // se llama a la función 'Jump'
        }
        if (Input.GetButtonDown("Fire1"))                                // si se pulsa el botón 'Fire1'
            
        {            
            am = FindObjectOfType<AnimationManagerGerard>();                 // se busca el objeto que tenga el script 'AnimationManager' y se guarda en la variable 'am'
            am.AttackAnimation();                                    // se llama a la función 'AttackAnimation()' del script 'AnimationManager' 
            
        }
    }

    private void PlayerMovement()                                           // función PlayerMovement()
    {
        xMovement = Input.GetAxisRaw("Horizontal");                       // se asigna el valor del eje "Horizontal2 a la variable xMovement.
        rb.velocity = new Vector2(xMovement * xspeed, rb.velocity.y);    // al valor "velocity" del rigidbody 2d "rb" se le asigna el valor en X : xMovement multiplicado por xspeed y se le deja en Y el valor que tenga.
    }
    void Jump()                                                              // función Jump()
    {
        if (isGrounded == true)                                             // si "isGrounded" es true;
        {
            rb.velocity = new Vector2(0, jump);                            // te permite saltar.
        }
    }
    void IsGrounded()                                                   // función IsGrounded()
    {
        RaycastHit2D ray = Physics2D.Raycast(rayOrigin.position, Vector2.down, 10f);         // usa un raycast 2D desde la posición "rayOrigin" en dirección hacia abajo y con un alcance de 10 unidades de Unity.

        if (ray.distance < 0.01f)                                                          // si el rayo choca con un objeto que este a una distancia menor de 0.01.
        {
            isGrounded = true;                                                           // activa el bool "isGrounded". 
        }
        else                                                                           // si el rayo no choca con un objeto que está a una distancia menor de 0.01.
        {
            isGrounded = false;                                                      // desactiva el bool "isGrounded".
        }
    }
}
