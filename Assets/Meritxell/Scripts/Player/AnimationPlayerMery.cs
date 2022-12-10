using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayerMery : MonoBehaviour      // Script que controla la mayoria de animaciones del player
{
    // private referencia que solo se usará esta información internamente en el GameObject, public permite otros elementos interactuar
    private Animator anim;            //  Animator se abreviará como anim y se asigna al Animator del objeto al que se asocie
    private Rigidbody2D rb;           //  "
    private SpriteRenderer sr;        //  "
    private PlayerMovementMery pm;    //  Referencia al script PlayerMovement
   
    public bool isShooting;           // Para interactuar con el bool 
    public bool isDucking;

    private void Start()

    {
        anim = GetComponent<Animator>();    // Las variables deben asignarse a los componentes si se usan en el script
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        pm = GetComponent<PlayerMovementMery>();
    }

    private void Update()
    {
        int n = Mathf.RoundToInt(rb.velocity.x);                              // n equivale a la velocidad a la que el rb se mueve en el axis x

        if (n != 0f)                                                          
        {
            anim.SetInteger("SpeedMovement", n);                             // SpeedMovement se modifica en base a n, si el valor no es zero
        }

        anim.SetInteger("SpeedMovement", Mathf.RoundToInt(rb.velocity.x));   // Se setea SpeedMovement del animator al rb.velocity.x
        anim.SetBool("Ground", pm.isGrounded);                               // Se setea Ground al bool isGrounded del script pm
      
        if (rb.velocity.x < -0.1)                                            // Si la velocidad en X es menor de -0.1
        {
            sr.flipX = true;                                                 // Se flipea en el eje X
        }
        else if (rb.velocity.x > 0.01)                                       // Si la velocidad en X no es menor de -0.1 y además es mayor de 0.01 (else indica que el parámetro anterior no se aplica además de aplicar el if)
        {
            sr.flipX = false;                                                
        }

        anim.SetBool("isShooting", pm.isShooting);              // Detecta si el personaje está disparando en pm

        anim.SetBool("isDucking", pm.isDucking);              // Detecta si el personaje está disparando en pm

    }
}