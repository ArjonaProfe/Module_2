using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowGerard : MonoBehaviour
{

    public Transform target;                     // se referencia el objetivo que seguir� la c�mara.
    public Vector3 offset;                      // se le asignar� el offset deseado.
    public float damping;                      // se guardar� el valor que afectar� al 'suavizado' con el que se mover� la c�mara.

    private Vector3 velocity = Vector3.zero; // se le asigna un valor cero a los 3 campos del vector3 velocity.

 
    
    void LateUpdate()
    {
        Vector3 movePosition = target.position + offset;    // se declara un nuevo vector 3 "movePosition" y se le asigna el valor de la posici�n del objeto m�s "offset" para "descolocar" la camara.
        transform.position = Vector3.SmoothDamp(transform.position, movePosition, ref velocity, damping); // la cam se mueve con un efecto de suavizado desde la posici�n en la que est� hasta la posici�n de "movePosition" a la velocidad que le indicamos en velocity y con el suavizado.
    }
}
