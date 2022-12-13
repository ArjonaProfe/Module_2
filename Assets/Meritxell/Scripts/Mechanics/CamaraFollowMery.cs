using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraFollowMery : MonoBehaviour        // Script de control de camara
{
    public Transform target;          // Target al que sigue
    public float damping;             // Suavizado
    public Vector2 maxPosition;       // Bordes de camara que no va a superar (x e y globales)
    public Vector2 minPosition;


    void Start()
    {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);                // Sigue al target de forma continua

    }

    void FixedUpdate()
    {
        if (CameraMery.mainCam.enabled == true)
        {
            if (transform.position != target.position)                                                                   // En case de que no estuviera siguiendo al target
            {
                Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);           // Seguir al target 

                targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);                             // Si la posición del target excede el maximo el el minimo, no lo seguirá
                targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);

                transform.position = Vector3.Lerp(transform.position, targetPosition, damping);                           // Suavizado
            }
        }
  
    }
}


