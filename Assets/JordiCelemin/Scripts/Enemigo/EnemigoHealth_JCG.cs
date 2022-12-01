using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoHealth_JCG : MonoBehaviour
{
    Enemigo_JCG enemy;

    public void Start()
    {
        enemy = GetComponent<Enemigo_JCG>();
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
