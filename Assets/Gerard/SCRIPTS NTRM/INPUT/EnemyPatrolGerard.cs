using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolGerard : MonoBehaviour
{

    private Rigidbody2D rb;
    private SpriteRenderer sp;

    public Transform waypointA;   // primer waypoint de la ruta
    public Transform waypointB;   // segundo waypoint de la ruta  

    public float speed;           // velocidad del enemigo
    private Transform target;     // objetivo que va a perseguir el enemigo

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        target = waypointA;       // Al principio, el objetivo ser� el waypoint A
    }

    void Update()
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

        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);  // Mueve la posici�n del enemigo desde donde est� hasta la posici�n del objetivo y lo hace a la velocidad 'Speed'
    }
}
