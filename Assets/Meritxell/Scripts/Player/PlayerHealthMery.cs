using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHealthMery : MonoBehaviour            // Script que controla el comportamiento del personaje al recibir da�o
{
    private Collider2D col;           // Componentes del player
    private Rigidbody2D rb;     
    private Animator anim;
    private PlayerLivesMery pl;      // Revisar

    public int healthPoints;         // Puntos de salud

    public float hurtJump;           // Salto f�sico al estar herido
    

    private void Start()
    {
        col = GetComponent<Collider2D>();                   // Se asignan las variables
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        pl = GetComponent<PlayerLivesMery>();              // Revisar

        healthPoints = HealthCounterMery.healthPoints;      // Los puntos de salud se cogen del contador       
    }

    private void OnCollisionEnter2D(Collision2D collision)                                // Si choca con un collider
    {

        if (collision.gameObject.tag == "Enemy")                                         // Y este tiene el tag enemy
        {
            HealthCounterMery.healthPoints = HealthCounterMery.healthPoints - 1;        // Se resta una vida directamente al contador  
            anim.SetBool("isHurt", true);                                               // Y se activa la animaci�n de da�o
                        
            rb.velocity = new Vector2(0, hurtJump);                                     // Vector2 que no afecta x pero causar� el valor de hurtJump en x sobre el RB
            Invoke("SetBoolBack", 0.5f);                                                // Tras el tiempo asignado, se invocar� la funci�n 
        }

        if (collision.gameObject.tag == "Enemy" && HealthCounterMery.healthPoints == 0)      // Independientemente del if anterior (else if causa que nunca avance porque siempre es verdadero), si choca con un enemy y no hya salud...
        { 
            PlayerLivesMery.Death();                                                    // Se llama la funci�n del script
        }
    }

    public void PlayerDamage()                          // Esta funci�n es identica a la anterior, se usa para el da�o causado por balas enemigas ya que no podemos llamar al void OnCollision desde el script del arma
    {
         HealthCounterMery.healthPoints = HealthCounterMery.healthPoints - 1;             
         anim.SetBool("isHurt", true);

         rb.velocity = new Vector2(0, hurtJump);
         Invoke("SetBoolBack", 0.5f);    

        if (HealthCounterMery.healthPoints == 0)           
        {
            PlayerLivesMery.Death();
        }
    }

    private void SetBoolBack()              // Void dise�ado para revertir un bool
    {
        anim.SetBool("isHurt", false);
    }
}