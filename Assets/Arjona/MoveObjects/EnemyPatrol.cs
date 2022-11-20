using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform waypoint1;   // 1� waypoint de la ruta
    public Transform waypoint2;   // 2� waypoint de la ruta  

    public float speed;           // velocidad del enemigo
    private Transform target;     // objetivo que va a perseguir el enemigo

    private void Start()
    {
        target = waypoint1;       // Al principio, el objetivo ser� el waypoint 1
    }

    void Update()
    {

        if (transform.position == waypoint1.position)       // Si el transform.position del enemigo es igual que el transform.position del waypoint ---->> (si los dos est�n en la misma posici�n) 
        {
            target = waypoint2;                             // El objetivo a perseguir se cambia al waypoint 2
        }
        else if (transform.position == waypoint2.position)  // Si el transform.position no encaja con el anterior pero encaja con el del waypoint 2
        {
            target = waypoint1;                               // El objetivo pasa a ser el waypoint 1
        }

        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);  // Mueve la posici�n del enemigo desde donde est� hasta la posici�n del objetivo y lo hace a la velocidad 'Speed'
    }
}
