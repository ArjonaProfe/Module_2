using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolGerard : MonoBehaviour
{
    public Transform waypointA;   // primer waypoint de la ruta
    public Transform waypointB;   // segundo waypoint de la ruta  

    public float speed;           // velocidad del enemigo
    private Transform target;     // objetivo que va a perseguir el enemigo

    private void Start()
    {
        target = waypointA;       // Al principio, el objetivo ser� el waypoint 1
    }

    void Update()
    {

        if (transform.position == waypointA.position)       // Si el transform.position del enemigo es igual que el transform.position del waypoint ---->> (si los dos est�n en la misma posici�n) 
        {
            target = waypointB;                             // El objetivo a perseguir se cambia al waypoint 2
        }
        else if (transform.position == waypointB.position)  // Si el transform.position no encaja con el anterior pero encaja con el del waypoint 2
        {
            target = waypointA;                               // El objetivo pasa a ser el waypoint 1
        }

        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);  // Mueve la posici�n del enemigo desde donde est� hasta la posici�n del objetivo y lo hace a la velocidad 'Speed'
    }
}
