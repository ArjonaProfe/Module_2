using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TriggerAnimationMery : MonoBehaviour
{

    public Rigidbody2D rb;
    public Animator anim;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()                                         // esto se ocupa de que se detecte SpeedMovement aka si el personaje se mueve
    {
        int n = Mathf.RoundToInt(rb.velocity.x);

        if (n != 0f)
        {
            anim.SetInteger("SpeedMovement", n);
        }
    }
}
