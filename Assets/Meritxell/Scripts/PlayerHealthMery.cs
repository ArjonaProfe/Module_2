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
    
    public float timer;             // Aquí se guardará el tiempo que pasará desde que se muere hasta que se carga la escena de nuevo
    public string sceneName;        // Aquí se guardará el nombre de la escena que se cargará cuando el personaje muera
    private bool activator = false; // Este bool servirá para avisar al script cuando el personaje muera

    void Start()
    {
        col = GetComponent<Collider2D>();   // Coge los componentes
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        healthPoints = LifeCounter.lifes;                  // Se iguala la variable 'lifes' de este script al valor que haya guardado en la variable 'lifes' del script 'LifeCounter'
        healthText.text = healthPoints.ToString();       // El texto 'lifesTextbos' mostrará el valor de la variable 'lifes'

        if (healthPoints == 3)
        {
            healthText.text = "3";
        }
        if (healthPoints == 2)
        {
            healthText.text = "2";
        }
        else if (healthPoints == 1)
        {
            healthText.text = "1";
        }
        else if (healthPoints == 0)
        {
            healthText.text = "0";
        }
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

    private void Update()
    {
        if (activator == true)                              // Si el bool 'activator' es true
        {
            timer = timer - 1 * Time.deltaTime;             // Se resta 1 unidad cada segundo a la variable 'timer' 
            if (timer < 0)                                  // Si el resultado de la operación es menor que cero
            {
                SceneManager.LoadScene(sceneName);          // Se carga de nuevo la escena guardada en la variable 'sceneName'
            }
        }
    }

    private void SetBoolBack()
    {
        anim.SetBool("isHurt", false);
    }
}
