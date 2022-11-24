using JetBrains.Annotations;          // Preguntar
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayerMery : MonoBehaviour
{
    // private referencia que solo se usará esta información internamente en el script; public is que utilizará elementos externos
    private Animator anim;            //  Animator se abreviará como anim y se asigna al Animator del objeto al que se asocie
    private Rigidbody2D rb;           //  "
    private SpriteRenderer sr;        //  "
    private PlayerMovementMery pm;    //  Referencia al script PlayerMovement
    public bool isShooting;

    private void Start()

    {
        anim = GetComponent<Animator>();    // Las variables deben asignarse a los componentes
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        pm = GetComponent<PlayerMovementMery>();
    }

    private void Update()
    {
        anim.SetInteger("SpeedMovement", Mathf.RoundToInt(rb.velocity.x));   // Se setea el entero 'SpeedMovement' del animator con el valor 'rb.velocity.x' 
        anim.SetBool("Ground", pm.isGrounded);                               // Se setea el bool 'Ground' del animator con el valor que hay en la variable 'isGrounded' del script 'pi'
      
        if (rb.velocity.x < -0.1)                                            // Si la velocidad en X es menor de -0.1
        {
            sr.flipX = true;                                                 // Se flipea en el eje X
        }
        else if (rb.velocity.x > 0.01)                                       // Si la velocidad en X no es menor de -0.1 y además es mayor de 0.01 (else indica que el parámetro anterior no se aplica además de aplicar el if)
        {
            sr.flipX = false;                                                
        }

        anim.SetBool("isShooting", pm.isShooting);              // detecta si el personaje está disparando en pm
        {
            if (Input.GetButton("Fire1") == true)              //input
            {
                isShooting = true;
            }
            else
            {
                isShooting = false;
            }
        }
        
    }
}