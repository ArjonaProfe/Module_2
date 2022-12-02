using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerHealthMery : MonoBehaviour
{
    private Collider2D col;
    private Rigidbody2D rb;
    private Animator anim;

    public Text healthText;
    public int healthPoints;


    public float deathJump;         // Aquí se guardará la potencia con la que el personaje saldrá disparado cuando muera 
    public float hurtJump;
    

    private void Start()
    {
        col = GetComponent<Collider2D>();   // Coge los componentes
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        healthPoints = HealthCounterMery.healthPoints;                  
        healthText.text = healthPoints.ToString();       
    }

    private void OnCollisionEnter2D(Collision2D collision)  // si choca con un collider
    {

        if (collision.gameObject.tag == "Enemy")           // y tiene el tag enemy
        {
            HealthCounterMery.healthPoints = HealthCounterMery.healthPoints - 1;     // Se resta una vida   
            anim.SetBool("isHurt", true);
                        

            rb.velocity = new Vector2(0, hurtJump);       
            Invoke("SetBoolBack", 0.5f);
        }

        else if (collision.gameObject.tag == "Enemy" && HealthCounterMery.healthPoints == 0)           // y tiene el tag enemy
        {
            anim.SetBool("isHurt", true);
            rb.velocity = new Vector2(0, deathJump);       // salto muerte
            col.enabled = false;
        }
    }

    public void PlayerDamage()
    {
            HealthCounterMery.healthPoints = HealthCounterMery.healthPoints - 1;     // Se resta una vida   
            anim.SetBool("isHurt", true);


            rb.velocity = new Vector2(0, hurtJump);
            Invoke("SetBoolBack", 0.5f);
       

        if (HealthCounterMery.healthPoints == 0)           // y tiene el tag enemy
        {
            anim.SetBool("isHurt", true);
            rb.velocity = new Vector2(0, deathJump);       // salto muerte
            col.enabled = false;
        }
    }

    private void SetBoolBack()
    {
        anim.SetBool("isHurt", false);
    }
}