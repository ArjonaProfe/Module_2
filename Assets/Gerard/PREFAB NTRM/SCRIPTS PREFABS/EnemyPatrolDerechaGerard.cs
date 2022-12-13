using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolDerechaGerard : MonoBehaviour
{

    private Rigidbody2D rb;
    private SpriteRenderer sp;

    public OnDeathEnemyGerard odeg;

    public Transform waypointA;   // primer waypoint de la ruta
    public Transform waypointB;   // segundo waypoint de la ruta  

    public float timerSpeed;           //timer para parar de moverse
    public float timerAttack;             //timer para hacer animación de ataque y volver a correr.
    public float timerSpeedPrivate;        // timer privado para cambiar valores.
    public float timerAttackPrivate;       // timer privado para cambiar valores.
    public float speedValue;

    public bool stopRun;

    public float speed;           // velocidad del enemigo
    private Transform target;     // objetivo que va a perseguir el enemigo

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        target = waypointA;       // Al principio, el objetivo será el waypoint A
        speedValue = speed;
        timerSpeedPrivate = timerSpeed;
        timerAttackPrivate = timerAttack;
    }

    void MovingToWaypoints()
    {
        float distance = Vector3.Distance(transform.position, target.position);
        if (distance < 0.5 && target == waypointA)       // Si el transform.position del enemigo es igual que el transform.position del waypoint 
        {
            target = waypointB;                             // El objetivo a perseguir se cambia al waypoint B
            sp.flipX = false;
        }
        else if (distance < 0.5 && target == waypointB)  // Si el transform.position no encaja con el anterior pero encaja con el del waypoint B
        {
            target = waypointA;                               // El objetivo pasa a ser el waypoint A
            sp.flipX = true;
        }
    }


    void RunTimer()
    {

        timerSpeedPrivate = timerSpeedPrivate - 1f * Time.deltaTime;
       
        if (timerSpeedPrivate < 0)
        {
            stopRun = true;
            speed = 0;
            timerAttackPrivate = timerAttackPrivate -1f * Time.deltaTime;
        }

        if (timerAttackPrivate < 0)
        {

            odeg = FindObjectOfType<OnDeathEnemyGerard>();
            speed = speedValue;
            timerAttackPrivate = timerAttack;
            timerSpeedPrivate = timerSpeed;
           // odeg.attacktime = odeg.attacktimereseter;
            stopRun = false;


        }

    }

    void Update()
    {
        MovingToWaypoints();
        RunTimer();

        if(stopRun == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);  // Mueve la posición del enemigo desde donde esté hasta la posición del objetivo y lo hace a la velocidad 'Speed'
        }

    }
}
