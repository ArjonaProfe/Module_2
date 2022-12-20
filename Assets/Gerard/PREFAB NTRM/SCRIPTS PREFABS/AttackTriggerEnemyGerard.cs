using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTriggerEnemyGerard : MonoBehaviour
{


    public ScoreManagerGerard smg;      // hacemos publuico el script ScoreManagerGerard para poder acceder a el y sumar y/o restar puntuación.
    public int minuspoints;             // le damos un valor integro a la resta de puntos si eres golpeado
    private bool gotHit;                 // hacemos publico el boleano gotHit para poder setearlo en el animator

    public Animator an;                  // hacemos publico el animator "an"




    void GotHitEvent()                   // funcion al ser golpeado para hacer saltar la animacion de ser golpeado.
    {

        gotHit = true;
        an.SetBool("GotHit", gotHit);
    }

    void MinusPoints()                      // funcion de restar puntos si eres golpeado por lo que lleve el script.
    {
        smg = FindObjectOfType<ScoreManagerGerard>();
        smg.minusScore = smg.minusScore - minuspoints;
        smg.score = smg.score + minuspoints;
    }

    private void OnTriggerEnter2D(Collider2D other)                   // poniendo las dos funciones anteriores en caso de activar el trigger.
    {
        if (other.CompareTag("Player"))
        {
            GotHitEvent();
            MinusPoints();
        }

    }


}
