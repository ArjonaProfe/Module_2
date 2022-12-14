using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnDeathEnemyGerard : MonoBehaviour
{
    public bool dead;
    public int lifepoints;
    public int deadpoints;
    public bool gothit;

    public Text life;

    public Animator an;

    public ScoreManagerGerard smg;


    void Start()
    {

        dead = false;
        an = GetComponent <Animator>();
    }

    void DeadPoints()
    {
        smg = FindObjectOfType<ScoreManagerGerard>();
        smg.score = smg.score + deadpoints;
    }

    void GotHit()
    {
        gothit = true;
        an.SetBool("GotHit", gothit);
    }

    void Dead()
    {
        dead = true;
        an.SetBool("Dead", dead);
    }

    void EnemyNumbers()
    {
        smg = FindObjectOfType<ScoreManagerGerard>();
        smg.enemiesNumber = smg.enemiesNumber - 1;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("PlayerAttack"))
        {

            GotHit();
            lifepoints = lifepoints - 1;
            life.text = lifepoints.ToString();

            if (lifepoints <= 0)
            {
                Dead();
                DeadPoints();
                EnemyNumbers();
                Destroy(gameObject, 0.7f);

            }

        }
    }

}
