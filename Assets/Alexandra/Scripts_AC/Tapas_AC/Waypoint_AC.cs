using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint_AC : MonoBehaviour
{
    public GameObject Pop;      //en Unity indicaremos qué objeto vamos a instanciar
    public Transform waypoint;  //punto a instanciar
    public float time;          //tiempo para instanciar
    private float resetTime;    //reset tiempo

    // Start is called before the first frame update
    void Start()
    {
        resetTime = time;       //asignamos que resetee el valor

    }

    // Update is called once per frame
    void Update()
    {
        time = time - 1 * Time.deltaTime;   //restará 1u/s
        if (time<0)
        {
            Instantiate(Pop, waypoint);     //mueve el objetivo al punto indicado
            time = resetTime;               //una vez hecho resetea la cuenta

        }
    }
}
