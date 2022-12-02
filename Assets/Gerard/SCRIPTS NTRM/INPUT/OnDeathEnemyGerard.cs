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
    public int minuspoints;

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
        Debug.Log(smg.score);
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
            Debug.Log(attacking);
            attacking = true;
            an.SetBool("Attack", attacking);
            attacktime = attacktimereseter;
            Debug.Log(attacking);
        }
    }

    void Dead()
    {
        dead = true;
        an.SetBool("Dead", dead);
    }

    void MinusPoints()
    {
        smg.minusScore = smg.minusScore + minuspoints;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            MinusPoints();
        }


        else if (other.tag == "PlayerAttack")
        {

            GotHit();
            lifepoints = lifepoints - 1;
            life.text = lifepoints.ToString();

            if(lifepoints == 0)
            {
                Dead();
                DeadPoints();
                Destroy(gameObject, 0.7f);

            }

        }
    }

    void Update()
    {
        AttackEnemy();
    }

}
