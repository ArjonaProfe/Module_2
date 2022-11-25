using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthMery : MonoBehaviour
{
    private Collider2D col;
    private Rigidbody2D rb;
    private Animator anim;
    public bool isHurt;

    public float deathJump;         // Aquí se guardará la potencia con la que el personaje saldrá disparado cuando muera 
    private float seconds;          // tiempo que dura la animación

    void Start()
    {
        col = GetComponent<Collider2D>();   // Coge los componentes
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)  // si choca con un collider
    {

        if (collision.gameObject.tag == "Enemy")           // y tiene el tag enemy
        {
            seconds = seconds + 1 * Time.deltaTime;        // Cada segundo que pasa se suma 1 unidad a la variable 'seconds'

            isHurt = true;
            if(seconds < 2)
            {
                isHurt = false;
            }

            anim.SetBool("isHurt", isHurt);

            LifeCounterMery.lifes = LifeCounterMery.lifes - 1;     // Se resta una vida                           
        }

        if (collision.gameObject.tag == "Enemy" && LifeCounterMery.lifes == 0)           // y tiene el tag enemy
        {
            rb.velocity = new Vector2(0, deathJump);       // salto muerte
            col.enabled = false;
        }
    }

}