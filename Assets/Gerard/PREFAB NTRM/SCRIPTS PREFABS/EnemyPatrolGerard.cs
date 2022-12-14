using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyPatrolGerard : MonoBehaviour
{
    public bool hasRangedAttack;
    public float attackCD;
    public float rangedCD;
    private float speedTimerInterno = 1f;
    public bool rangedAttacking;


    public bool attackCheck;
    public bool rangedCheck;


    public bool isFlipped;
    public SpriteRenderer sr;
    public GameObject BulletEnemy;
    public Transform waypointRight;
    public Transform waypointLeft;
    

    public AnimationManager anim;
    public Animator an;


    private float timerInterno = 0f;
    public bool gothit;
    public int deadpoints;
    public bool attacking;
    public Text life;
    public int lifepoints;

    private SpriteRenderer sp;

    public Transform waypointA;   // primer waypoint de la ruta
    public Transform waypointB;   // segundo waypoint de la ruta  

    public float speedValue;

    public bool stopRun;

    public float speed;           // velocidad del enemigo
    private Transform target;     // objetivo que va a perseguir el enemigo
    public ScoreManagerGerard smg;

    private void Start()
    {

        sp = GetComponent<SpriteRenderer>();
        target = waypointA;                          // Al principio, el objetivo será el waypoint A
        speedValue = speed;
        an = GetComponent<Animator>();
        attackCheck = false;
        rangedCheck = false;

    }




    void GlobalTimer()
    {

        timerInterno = timerInterno + 1 * Time.deltaTime;
        if (timerInterno > 10)
        {
            timerInterno = 0f;
        }
    }


    void MovingToWaypoints()
    {
        float distance = Vector3.Distance(transform.position, target.position);
        if (distance < 0.5 && target == waypointA)       // Si el transform.position del enemigo es igual que el transform.position del waypoint 
        {
            target = waypointB;                             // El objetivo a perseguir se cambia al waypoint B
            sp.flipX = true;
        }
        else if (distance < 0.5 && target == waypointB)  // Si el transform.position no encaja con el anterior pero encaja con el del waypoint B
        {
            target = waypointA;                               // El objetivo pasa a ser el waypoint A
            sp.flipX = false;
        }
    }

    void AttackEnemy()
    {
        attackCheck = true;
        speedTimerInterno = speedTimerInterno - 1f * Time.deltaTime;
        stopRun = true;
        speed = 0;
        attacking = true;
        an.SetBool("Attack", attacking);

        if (speedTimerInterno < 0.5f)
        {
            speed = speedValue;
            stopRun = false;
            speedTimerInterno = 1f;

        }

        if (speedTimerInterno < 00.5f && hasRangedAttack == false)
        {
            speed = speedValue;
            stopRun = false;
            speedTimerInterno = 1f;
            timerInterno = 0f;

        }

    }


    void BulletFlip()
    {
        if (sr.flipX == true)
        {
            Instantiate(BulletEnemy, waypointLeft.position, waypointLeft.rotation);
        }
        else
        {
            Instantiate(BulletEnemy, waypointRight.position, waypointRight.rotation);
        }
    }

    void Bullet()
    {
        speedTimerInterno = speedTimerInterno - 1 * Time.deltaTime;
        stopRun = true;
        speed = 0;
        BulletFlip();
        an.SetBool("RangedAttack", rangedAttacking);

        if (speedTimerInterno < 0.5f)
        {
            speed = speedValue;
            stopRun = false;
            speedTimerInterno = 1f;
            timerInterno = 0f;
        }

    }

    void Update()
    {
        GlobalTimer();
        MovingToWaypoints();

        if(timerInterno > attackCD && attackCheck == false)
        {
            AttackEnemy();
        }

        attackCheck = true;

        if (timerInterno >= rangedCD)
        {
            Bullet();
        }

        else if (stopRun == false)
        {
            speed = speedValue;
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);  // Mueve la posición del enemigo desde donde esté hasta la posición del objetivo y lo hace a la velocidad 'Speed'
        }

    }
}
