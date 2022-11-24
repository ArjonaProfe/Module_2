using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DyingMery : MonoBehaviour
{
    private Collider2D col;         
    private Rigidbody2D rb;        

    public float deathJump;         // Aquí se guardará la potencia con la que el personaje saldrá disparado cuando muera 
    

    void Start()
    {
        col = GetComponent<Collider2D>();   // Coge los componentes
        rb = GetComponent<Rigidbody2D>();   
    }

    private void OnCollisionEnter2D(Collision2D collision)  // si choca con un collider
    {
        if (collision.gameObject.tag == "Enemy")           // y tiene el tag enemy
        {
            LifeCounterMery.lifes = LifeCounterMery.lifes - 1;     // Se resta una vida                           
        }

        if (collision.gameObject.tag == "Enemy" && LifeCounterMery.lifes == 0)           // y tiene el tag enemy
        {
            rb.velocity = new Vector2(0, deathJump);       // salto muerte
            col.enabled = false;
        }
    }
}