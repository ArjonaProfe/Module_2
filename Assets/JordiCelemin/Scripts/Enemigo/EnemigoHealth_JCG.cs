using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemigoHealth_JCG : MonoBehaviour
{
    Enemy_JCG enemy;
    
    public void Start()
    {
        enemy = GetComponent<Enemy_JCG>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerAttack"))
        {
            enemy.healthPoints -= 2f;

            if(enemy.healthPoints < 0)
            {
                ScoreManagerAtaque_JCG.scoreValue += 10;
                Destroy(gameObject);
               
            }
        }
    }
}
