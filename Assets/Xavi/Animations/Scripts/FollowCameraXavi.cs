using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCameraXavi : MonoBehaviour

{
    public Transform target;                // Aquí se referenciará el objetivo que seguirá la cámara 
    public Vector3 offset;                  // Aquí se le asignará el offset deseado
    public float damping;                   // Aquí se guardará el valor que afectará al 'suavizado' con el que se moverá la cámara

    private Vector3 velocity = Vector3.zero; // Se le asigna un valor cero a los 3 campos del vector3 'velocity'  ---> (0 en X, 0 en Y, 0 en Z)


    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 movePosition = target.position + offset;    // Se declara un nuevo vector 3 'movePosition' y se le asigna el valor de la posición del objeto más 'offset'
        transform.position = Vector3.SmoothDamp(transform.position, movePosition, ref velocity, damping); //La cámara se moverá con un efecto de suavizado desde la posición en la que está hasta la posición de 'movePosition' a la velocidad 'velocity' y con el suavizado 'damping'
    }
}
