using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateScript : MonoBehaviour
{
    public GameObject triangle;     //Aqu� se guardar� el prefab 'triangle'
    public GameObject hexagon;      //Aqu� se guardar� el prefab 'hexagon'

    public Transform[] waypoints;   //Esto es un array de waypoints

    public void TriangleInst()      // A la funci�n 'TriangleInst()' se le llamar� desde el correspondiente bot�n del canvas
    {
        Instantiate(triangle, waypoints[0]);  //Se instanciar� el prefab 'triangle' en la posici�n del waypoint[0]
    }

    public void HexagonInst()       // A la funci�n 'Hexagon()' se le llamar� desde el correspondiente bot�n del canvas
    {
        Instantiate(hexagon, waypoints[1]);     //Se instanciar� el prefab 'triangle' en la posici�n del waypoint[1]
    }
}
