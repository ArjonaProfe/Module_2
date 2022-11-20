using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{

    private Animator anim;            //  Aquí se asignará el componente 'Animator' 
    private Rigidbody2D rb;           //  Aquí se asignará el componente 'rigidbody2D'
    private SpriteRenderer sr;        //  Aquí se asignará el componente 'spriteRenderer'
    private PlayerInput pi;           //  Aquí se está referenciando el scripty 'PlayerInput'
    public bool attack;               //  Bool que servirá para comprobar cuando el personaje está atacando
    private void Start()

    {
        anim = GetComponent<Animator>();    // Se asigna el componente 'Animator' a la variable 'anim'
        rb = GetComponent<Rigidbody2D>();   // Se asigna el componente 'Rigidbody2D' a la variable 'rb'
        sr = GetComponent<SpriteRenderer>();// Se asigna el componente 'SpriteRenderer' a la variable 'sr'
        pi = GetComponent<PlayerInput>();   // Se asigna el componente 'PlayerInput' a la variable 'pi'
    }


    private void Update()
    {
        anim.SetInteger("SpeedMovement", Mathf.RoundToInt(rb.velocity.x));   // Se setea el entero 'SpeedMovement' del animator con el valor 'rb.velocity.x' redondeado a entero
        anim.SetBool("Ground", pi.isGrounded);                               // Se setea el bool 'Ground' del animator con el valor que hay en la variable 'isGrounded' del script 'pi'
        if (rb.velocity.x < -0.1)                                            // Si la velocidad en X es menor de -0.1
        {
            sr.flipX = true;                                                 // Se flipea en el eje X el sprite 'sr'
        }
        else if (rb.velocity.x > 0.01)                                       // Si la velocidad en X no es menor de -0.1 y además es mayor de 0.01
        {
            sr.flipX = false;                                                // Se desactiva el flip en el eje X del sprite 'sr'
        }
        anim.SetBool("Attack", attack);                                      // Se setea el bool 'Attack' con el valor que hay en la variable 'attack' 

    }
    public void AttackAnimation()                                             // Función encargada de activar el bool "attack" 
    {
        attack = true;
    }
  
}
