using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyPatrolRangedGerard : MonoBehaviour
{


    public float attackCooldown;
    private float attackCD;
    private float speedTimerInterno = 1f;


    public bool isFlipped;
    public SpriteRenderer sr;
    public GameObject BulletEnemy;
    public Transform waypointRight;
    public Transform waypointLeft;
    

    public Animator an;

    public bool attacking;



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
        attackCD = attackCooldown;

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




    void EnemyAttackingRanged()
    {
            Bullet();
            attackCD = attackCooldown;
    }



    void BulletFlip()
    {
        if (sr.flipX == false)
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
        speed = 0;
        speedTimerInterno = speedTimerInterno - 1 * Time.deltaTime;
        attacking = true;
        BulletFlip();
        an.SetBool("Attack", attacking);

        if (speedTimerInterno < 0f)
        {
            speed = speedValue;
            stopRun = false;
            speedTimerInterno = 1f;
            attacking = false;
        }

    }

    void Update()
    {

        MovingToWaypoints();
        attackCD = attackCD - 1f * Time.deltaTime;

        if (attackCD < 0)
        {
            stopRun = true;
            EnemyAttackingRanged();
            attacking = false;
        }

        if (stopRun == false)
        {
            speed = speedValue;
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);  // Mueve la posición del enemigo desde donde esté hasta la posición del objetivo y lo hace a la velocidad 'Speed'
        }

    }
}
