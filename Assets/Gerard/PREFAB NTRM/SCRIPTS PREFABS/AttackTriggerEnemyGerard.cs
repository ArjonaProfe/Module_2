using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTriggerEnemyGerard : MonoBehaviour
{


    public ScoreManagerGerard smg;
    public int minuspoints;



    void MinusPoints()
    {
        smg = FindObjectOfType<ScoreManagerGerard>();
        smg.minusScore = smg.minusScore + minuspoints;
        smg.score = smg.score + minuspoints;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            MinusPoints();
        }

    }


}
