using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangMovementGerard : MonoBehaviour
{
    public float speed;                           // asignamos un numero a speed para poder controlar la velocidad.
    private float timertocome = 0.5f;                   // asignamos un valor a timertocome para poder hacer que el boomerang nos vuelva al llegar a 0 el contador.  
    private SpriteRenderer thisSr;                      //  se asigna el componente "spriteRenderer" a thisSr.
    public Rigidbody2D rb;                              // se asigna el componente "X" a rb.




    void Update()
    {
        thisSr = GetComponent<SpriteRenderer>();
        timertocome = timertocome - 1 * Time.deltaTime;                 // restamos tiempo al timer para que encaje en las variables.

        if (timertocome > 0)
        { 
        rb.velocity = transform.right * speed;
        }

        else if (timertocome < 0)
        {
            thisSr.flipX = true;
        rb.velocity = - transform.right * speed;
        }

        Destroy(gameObject, 1f);
    }




}
