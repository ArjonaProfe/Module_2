using JetBrains.Annotations;          // Preguntar
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayerMery : MonoBehaviour
{
    // private referencia que solo se usará esta información internamente en el script; public is que utilizará elementos externos
    private Animator anim;            //  Animator se abreviará como anim (no es el componente en si?)
    private Rigidbody2D rb;           //  "
    private SpriteRenderer sr;        //  "
    private PlayerMovementMery pi;    //  Referencia al script PlayerMovement
    public bool attack;               //  Bool que servirá para comprobar cuando el personaje está atacando
    private void Start()

    {
        anim = GetComponent<Animator>();    // Las variables deben asignarse a los componentes
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        pi = GetComponent<PlayerMovementMery>();
    }

    // Se comprueba en cada frame
    private void Update()
    {
        anim.SetInteger("SpeedMovement", Mathf.RoundToInt(rb.velocity.x));   // Se setea el entero 'SpeedMovement' del animator con el valor 'rb.velocity.x' redondeado a entero
        anim.SetBool("Ground", pi.isGrounded);                               // Se setea el bool 'Ground' del animator con el valor que hay en la variable 'isGrounded' del script 'pi'
        if (rb.velocity.x < -0.1)                                            // Si la velocidad en X es menor de -0.1
        {
            sr.flipX = true;                                                 // Se flipea en el eje X el sprite 'sr'
        }
        else if (rb.velocity.x > 0.01)                                       // Si la velocidad en X no es menor de -0.1 y además es mayor de 0.01 (else indica que el parámetro anterior no se aplica además de aplicar el if)
        {
            sr.flipX = false;                                                // Se desactiva el flip en el eje X del sprite 'sr'
        }
        anim.SetBool("Attack", attack);                                      // Se setea el bool 'Attack' con el valor que hay en la variable 'attack' 

    }
    public void AttackAnimation()                                             // Función encargada de activar el bool "attack" en el Animator
    {
        attack = true;
    }

}