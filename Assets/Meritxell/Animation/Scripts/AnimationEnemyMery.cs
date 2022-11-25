using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEnemyMery : MonoBehaviour
{
    // private referencia que solo se usará esta información internamente en el script; public is que utilizará elementos externos
    private Animator anim;            //  Animator se abreviará como anim y se asigna al Animator del objeto al que se asocie
    private Rigidbody2D rb;           //  "
    private SpriteRenderer sr;        //  "

    private EnemyMery em;

    private void Start()
    {
        anim = GetComponent<Animator>();    // Las variables deben asignarse a los componentes
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        em = GetComponent<EnemyMery>();
    }

    private void Update()
    {
        rb.velocity = new Vector2(em.xMovement * em.speed, rb.velocity.y);
        anim.SetInteger("SpeedMovement", Mathf.RoundToInt(rb.velocity.x));   // Se setea el entero 'SpeedMovement' del animator con el valor 'rb.velocity.x' 

        if (rb.velocity.x < -0.9)                                            // Si la velocidad en X es menor de -0.1
        {
            sr.flipX = false;                                                 // Se flipea en el eje X
        }
        else if (rb.velocity.x > 1)                                       // Si la velocidad en X no es menor de -0.1 y además es mayor de 0.01 (else indica que el parámetro anterior no se aplica además de aplicar el if)
        {
            sr.flipX = true;
        }
    }
}
