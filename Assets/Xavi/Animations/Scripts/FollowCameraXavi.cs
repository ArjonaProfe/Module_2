using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCameraXavi : MonoBehaviour

{
    public Transform target;                // Aqu� se referenciar� el objetivo que seguir� la c�mara 
    public Vector3 offset;                  // Aqu� se le asignar� el offset deseado
    public float damping;                   // Aqu� se guardar� el valor que afectar� al 'suavizado' con el que se mover� la c�mara

    private Vector3 velocity = Vector3.zero; // Se le asigna un valor cero a los 3 campos del vector3 'velocity'  ---> (0 en X, 0 en Y, 0 en Z)


    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 movePosition = target.position + offset;    // Se declara un nuevo vector 3 'movePosition' y se le asigna el valor de la posici�n del objeto m�s 'offset'
        transform.position = Vector3.SmoothDamp(transform.position, movePosition, ref velocity, damping); //La c�mara se mover� con un efecto de suavizado desde la posici�n en la que est� hasta la posici�n de 'movePosition' a la velocidad 'velocity' y con el suavizado 'damping'
    }
}
