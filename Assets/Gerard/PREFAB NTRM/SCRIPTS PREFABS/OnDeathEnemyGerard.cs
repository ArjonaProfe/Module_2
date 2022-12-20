using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnDeathEnemyGerard : MonoBehaviour
{
    public bool dead;                           // hacemos publico un boleano para controlar animaciones
    public int lifepoints;                      // hacemos publico un integro para darle valor a los puntos de vida
    public int deadpoints;                      // hacemos un integro para darle valor a los puntos que sumamos al score una vez muerto el enemigo
    public bool gothit;                         // hacemos publico un boleano para controlar la animacion al ser golpeado

    public Text life;                           // hacemos publico un texto donde nos servira para poner el valor de la vida del enemigo

    public Animator an;                         // hacemos publico y nombramos el animator como "an"

    public ScoreManagerGerard smg;              // hacemos accesible es script para modificar los puntos.


    void Start()
    {
            
        dead = false;                           // seteamos boleano en falso
        an = GetComponent <Animator>();          // cogemos el componente Animator
    }

    void DeadPoints()                       // funcion que suma puntos al scoremanager
    {
        smg = FindObjectOfType<ScoreManagerGerard>();
        smg.score = smg.score + deadpoints;
    }

    void GotHit()                       // funcion que activa el boleano del animator para condicionarlo y lanzar una animacion
    {
        gothit = true;
        an.SetBool("GotHit", gothit);
    }

    void Dead()                         // funcion que activa el boleano del animator para condicionarlo y lanzar una animacion
    {
        dead = true;
        an.SetBool("Dead", dead);
    }

    void EnemyNumbers()                 // función para restar el numero de enemigos que quedan cuando el enemigo que lelva el script muera
    {
        smg = FindObjectOfType<ScoreManagerGerard>();
        smg.enemiesNumber = smg.enemiesNumber - 1;
    }

    private void OnTriggerEnter2D(Collider2D other)             // funcion del trigger, para que cuando el player ataque llame a la funcion de ser golpeado y una vez los puntos de vida lleguen a 0 el enemigo sume puntos y desaparezca.
    {

        if (other.CompareTag("PlayerAttack"))
        {

            GotHit();
            lifepoints = lifepoints - 1;
            life.text = lifepoints.ToString();

            if (lifepoints == 0)
            {
                Dead();
                DeadPoints();
                EnemyNumbers();
                Destroy(gameObject, 0.7f);

            }

        }
    }

}
