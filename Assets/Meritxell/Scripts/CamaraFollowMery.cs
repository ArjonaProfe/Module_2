using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraFollowMery : MonoBehaviour
{
    public Transform target;       // Objetivo
    public float damping;          // Suavizado
    public Vector2 maxPosition;       // Bordes de camara
    public Vector2 minPosition;

    void Start()
    {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);                // Colocarse en el target
    }

    void FixedUpdate()
    {
        if (transform.position != target.position)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);           // seguir al target

            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);                             // no superar un borde aunque el target se acerce
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);

            transform.position = Vector3.Lerp(transform.position, targetPosition, damping);                           // Suavizado
        }
    }
}


