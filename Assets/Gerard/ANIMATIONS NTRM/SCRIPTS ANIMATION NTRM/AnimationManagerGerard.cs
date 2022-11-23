using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManagerGerard : MonoBehaviour
{


    private Animator anim;                  //  se asigna el componente "Animator". 
    private SpriteRenderer sr;             //  se asigna el componente "spriteRenderer".
    private Rigidbody2D rb;               // hago de forma privada que el Rigidbody2D sea accesible desde el parametro rb.
    public bool attack;                 // nos indicará cuando el personaje está atacando.
    private MovementGerard pi;

    private void Start()
    {

        anim = GetComponent<Animator>();             // se asigna el componente "Animator" a la variable "anim".
        rb = GetComponent<Rigidbody2D>();           // se asigna el componente "Rigidbody2D" a la variable "rb".
        sr = GetComponent<SpriteRenderer>();       // se asigna el componente "SpriteRenderer" a la variable "sr".
        pi = GetComponent<MovementGerard>();      // se asigna el componente "MovementGerard" a la variable "pi".

    }

    
    private void Update()
    {


        anim.SetInteger("SpeedMovement", Mathf.RoundToInt(rb.velocity.x));   // se configura el entero "SpeedMovement" del animator con el valor "rb.velocity.x" para redondearlo a entero.
        anim.SetBool("Ground", pi.isGrounded);                               // se configura el bool "Ground" del animator con el valor que hay en la variable "isGrounded" del script "pi".
        if (rb.velocity.x < -0.1)                                            // si la velocidad en X es menor de -0.1.
        {
            sr.flipX = true;                                                 // se gira en el eje X del sprite "sr".
        }
        else if (rb.velocity.x > 0.01)                                       // si la velocidad en X no es menor de -0.1 y además es mayor de 0.01.
        {
            sr.flipX = false;                                                // se desactiva el flip en el eje X del sprite "sr".
        }
        anim.SetBool("Attack", attack);                                      // se setea el bool "Attack" con el valor que hay en la variable "attack".
       
    }

    public void AttackAnimation()                                             // activa el bool "attack". 
    {
        attack = true;
        Debug.Log("hola");
    }


}
