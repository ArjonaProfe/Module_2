using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEnemyMery : MonoBehaviour
{
    // private referencia que solo se usará esta información internamente en el script; public is que utilizará elementos externos
    private Animator anim;            //  Animator se abreviará como anim y se asigna al Animator del objeto al que se asocie
    private Rigidbody2D rb;           //  "
    private SpriteRenderer sr;        //  "

    public float xMovement;
    public float speed;

    private void Start()
    {
        anim = GetComponent<Animator>();    // Las variables deben asignarse a los componentes
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        rb.velocity = new Vector2(xMovement * speed, rb.velocity.y);
        anim.SetInteger("SpeedMovement", Mathf.RoundToInt(rb.velocity.x));   // Se setea el entero 'SpeedMovement' del animator con el valor 'rb.velocity.x' 

        if (rb.velocity.x < -0.9)                                            // Si la velocidad en X es menor 
        {
            sr.flipX = false;                                                 // Se flipea en el eje X
        }
        else if (rb.velocity.x > 1)                                       // (else indica que el parámetro anterior no se aplica además de aplicar el if)
        {
            sr.flipX = true;
        }
    }
}
