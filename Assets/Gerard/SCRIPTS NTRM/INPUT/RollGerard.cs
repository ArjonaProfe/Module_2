using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollGerard : MonoBehaviour
{

    public float xRoll;                       // hago publico el parametro xRoll para añadirle velocidad al Roll.
    private Rigidbody2D rb;                  // hago privado la asiganción de RigidBody2D a rb.
    private float rollCD;                   //  hago privado el parametro rollCD para poder ponerle un CD.
    public float nextRoll;
    private SpriteRenderer sr;             //  se asigna el componente "spriteRenderer".
    public bool isGrounded;               // aquí se comnprueba si el personaje está tocando el suelo.
    public Transform rayOrigin;          // aquí se asigna el punto desde el que se lanza el raycast.
    private AnimationManagerGerard am;        // aquí se referencia el script "AnimationManagerGerard".
    public bool rollisgoing;
    private Animator anim;                      //  se asigna el componente "Animator". 


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();                // coge el RigidBody2D el objeto en el que está el Script.
        sr = GetComponent<SpriteRenderer>();          // coge el SpriteRenderer el objeto en el que está el Script.
        anim = GetComponent<Animator>();                // se asigna el componente "Animator" a la variable "anim".
    }

    void IsGrounded()                                                                         // función IsGrounded()
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

    void RollAnimation()
    {
            rollisgoing = true;
            anim.SetBool("Roll", rollisgoing);
    }



    private void RollYeah()
    {
        if (Input.GetButton("Fire3") && sr.flipX == false && isGrounded == true)                            // si se pulsa L Shift y esta en el suelo y no está flip marcado, hace un "roll" hacia la derecha.
        {
            RollAnimation();
            rb.AddForce(transform.right * xRoll);
        }

        else if (Input.GetButton("Fire3") && sr.flipX == true && isGrounded == true)                        // si se pulsa L Shift y esta en el suelo y está flip marcado, hace un "roll" hacia la izquierda.
        {
            RollAnimation();
            rb.AddForce(transform.right * -1 * xRoll);
        }
    }


    void RollCooldown()
    {
        rollCD = rollCD - 1 * Time.deltaTime;
        if (rollCD < 0 && Input.GetButton("Fire3"))
        {
            RollYeah();
            rollCD = nextRoll;
        }
    }

    void Update()
        {
            IsGrounded();                                                                                      // se llama a la función IsGrounded.
            RollCooldown();
        }

}

