using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyXavi : MonoBehaviour
{

    Rigidbody2D myRigidbody;
    Animator myAnimator;

    [SerializeField] float speedX = 5f;

    public Transform waypoint1;   // 1º waypoint de la ruta
    public Transform waypoint2;
    private Transform target;     // objetivo que va a perseguir el enemigo

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        target = waypoint1;     // Al principio, el objetivo será el waypoint 1
    }
    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);
        if (distance < 0.5 && target == waypoint1)       // Si el transform.position del enemigo es igual que el transform.position del waypoint ---->> (si los dos están en la misma posición) 
        {
            target = waypoint2;                             // El objetivo a perseguir se cambia al waypoint 2
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (distance < 0.5 && target == waypoint2)  // Si el transform.position no encaja con el anterior pero encaja con el del waypoint 2
        {
            transform.localScale = new Vector3(1, 1, 1);
            target = waypoint1;                               // El objetivo pasa a ser el waypoint 1
        }
        transform.position = Vector2.MoveTowards(transform.position, target.position, speedX * Time.deltaTime);  // Mueve la posición del enemigo desde donde esté hasta la posición del objetivo y lo hace a la velocidad 'Speed'
    }
}
