using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateScript : MonoBehaviour
{
    public GameObject triangle;     //Aquí se guardará el prefab 'triangle'
    public GameObject hexagon;      //Aquí se guardará el prefab 'hexagon'

    public Transform[] waypoints;   //Esto es un array de waypoints

    public void TriangleInst()      // A la función 'TriangleInst()' se le llamará desde el correspondiente botón del canvas
    {
        Instantiate(triangle, waypoints[0]);  //Se instanciará el prefab 'triangle' en la posición del waypoint[0]
    }

    public void HexagonInst()       // A la función 'Hexagon()' se le llamará desde el correspondiente botón del canvas
    {
        Instantiate(hexagon, waypoints[1]);     //Se instanciará el prefab 'triangle' en la posición del waypoint[1]
    }
}
