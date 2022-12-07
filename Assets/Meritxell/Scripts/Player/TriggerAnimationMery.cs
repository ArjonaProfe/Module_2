using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TriggerAnimationMery : MonoBehaviour  // Este script aseguraba que se detectase el movimiento, pero ya no lo uso. Guardado por si acaso
{

    private Rigidbody2D rb;
    private Animator anim;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()                                         
    {
        int n = Mathf.RoundToInt(rb.velocity.x);

        if (n != 0f)
        {
            anim.SetInteger("SpeedMovement", n);
        }
    }
}
