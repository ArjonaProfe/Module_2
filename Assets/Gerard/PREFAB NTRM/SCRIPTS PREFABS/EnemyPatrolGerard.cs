using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyPatrolGerard : MonoBehaviour
{


    public float attackCooldown;            // hacemos publico un numero X para darle CD al ataque
    private float attackCD;                 // hacemos privado un numero para resetear el valor anterior
    private float speedTimerInterno = 1f;   // hacemos privado un numero para hacer un contador de tiempo

    public bool isFlipped;                  // hacemos publico un boleano para controlar el sentido en el que mira el sprite
    public SpriteRenderer sr;               // hacemos que el SpriteRenderer sea conocido como sr
    public GameObject BulletEnemy;          // hacemos que un gameObject sea llamado BulletEnemy
    public Transform waypointRight;         // un objecto con transform (cordenadas) lo seteamos como publico.
    public Transform waypointLeft;
    

    public Animator an;                     // denominamos an al Animator que se coloque en ello

    public bool attacking;                  // hacemos publico un boleano para saber cuando estamos atacando
    private bool stopRunningCheck = true;   // hacemos un bolano privado para setear otro mas adelante.


    private SpriteRenderer sp;              // hacemos privado el spriteRenderer con "sp"

    public Transform waypointA;   // primer waypoint de la ruta
    public Transform waypointB;   // segundo waypoint de la ruta  

    public float speedValue;        // valor de velocidad para copiarlo y resetear el speed.

    public bool stopRun;            // boleano para controlar cuando para el movimiento.

    public float speed;           // velocidad del enemigo
    private Transform target;     // objetivo que va a perseguir el enemigo
    public ScoreManagerGerard smg;      // scoremanager pasa a ser smg

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


    void CheckAnimatorRun()
    {
         stopRun = false;
    }

    void EnemyAttackingMelee()
    {
            AttackEnemy();
            attackCD = attackCooldown;

    }



    void AttackEnemy()
    {
        speed = 0;
        speedTimerInterno = speedTimerInterno - 1f * Time.deltaTime;
        attacking = true;
        stopRun = stopRunningCheck;
        an.SetBool("Attack", attacking);

        if (speedTimerInterno < 0f)
        {
            speed = speedValue;
            CheckAnimatorRun();
            speedTimerInterno = 1f;
            attacking = false;
            Debug.Log(attacking = false);

        }

    }


    void Update()
    {

        MovingToWaypoints();
        attackCD = attackCD - 1f * Time.deltaTime;


        if (attackCD < 0)
        {
            
            EnemyAttackingMelee();
            attacking = false;

        }


        else 
        {
            speed = speedValue;
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);  // Mueve la posición del enemigo desde donde esté hasta la posición del objetivo y lo hace a la velocidad 'Speed'
        }

    }
}
