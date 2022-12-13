using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnDeathEnemyGerard : MonoBehaviour
{
    public bool dead;
    public int lifepoints;
    public int deadpoints;
    public float attacktime;
    public bool attacking;
    public bool gothit;
    public float attacktimereseter;
  //  public int minuspoints;

    public int numberEnemies;


    public Text life;

    public AnimationManager anim;
    public Animator an;

    public ScoreManagerGerard smg;


    void Start()
    {
        anim = GetComponent<AnimationManager>();
        dead = false;
        an = GetComponent <Animator>();
        attacktimereseter = attacktime;
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

    void AttackEnemy()
    {
        attacktime = attacktime - 1 * Time.deltaTime;
        Debug.Log(attacktime);
        if (attacktime < 0)
        {

            attacking = true;
            an.SetBool("Attack", attacking);
            attacktime = attacktimereseter;
        }
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


    /*
    void MinusPoints()
    {
        smg = FindObjectOfType<ScoreManagerGerard>();
        smg.minusScore = smg.minusScore + minuspoints;
        smg.score = smg.score + minuspoints;
    }
    */

    private void OnTriggerEnter2D(Collider2D other)
    {
      
        /*
        if (other.CompareTag ("Player"))
        {
            MinusPoints();
        }
        */


        if (other.CompareTag ("PlayerAttack"))
        {

            GotHit();
            lifepoints = lifepoints - 1;
            life.text = lifepoints.ToString();

            if(lifepoints == 0)
            {
                Dead();
                DeadPoints();
                EnemyNumbers();
                Destroy(gameObject, 0.7f);

            }

        }
    }

    void Update()
    {
        AttackEnemy();
    }

}
