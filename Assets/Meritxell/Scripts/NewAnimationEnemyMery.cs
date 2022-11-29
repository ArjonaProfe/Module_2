using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;

public class NewAnimationEnemyMery : MonoBehaviour
{
    // private referencia que solo se usará esta información internamente en el script; public is que utilizará elementos externos
    private Animator anim;            //  Animator se abreviará como anim y se asigna al Animator del objeto al que se asocie
    private SpriteRenderer sr;        //  "
    private Rigidbody2D rb;
    float direction = 1;
    public float speed;

    private Vector2 change;                  // Vector 2 debería coger los valores x e y del objecto


    private void Start()
    {
         
        anim = GetComponent<Animator>();    // Las variables deben asignarse a los componentes
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();


        anim.SetFloat("xMovement", 0);            // El float que controla la direción (necesita ser asignado)
        
    }

    private void Update()
    {
        change = Vector2.zero;                    // asigna los valores x0, y0
        change.x = speed;                   // según xMovement se modifica cuando cuando change.x lo hace, lo que se basa en el speed

        MoveEnemy();
        Animation();
    }
    void MoveEnemy()
    {      
        direction = direction - speed * Time.deltaTime;                        // Era necesario establecer cuanto iba a avanzar en esa dirección
        transform.position = new Vector2(direction, transform.position.y);
    }

    void Animation()                                       // si el vector2 no es igual a zero, cambia el valor de xMovement y de isMoving, cambiando la animación 
    {
         if (change != new Vector2(0, 0))
         {
              anim.SetFloat("xMovement", change.x);
              anim.SetBool("isMoving", true);
         }
         else
         {
              anim.SetBool("isMoving", false);
         }
    }
}

