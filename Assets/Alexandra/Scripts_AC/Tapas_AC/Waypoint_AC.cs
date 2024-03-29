using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Waypoint_AC : MonoBehaviour     //script para instanciar las plataformas de forma random
{
    public GameObject[] Pops;       //en Unity indicaremos qu� objeto vamos a instanciar, []indicamos que hay m�s de 1 objeto
    public Transform[] waypoint;    //punto a instanciar
    public float time;              //tiempo para instanciar
    private float resetTime;        //reset tiempo
    private int number;             

    // Start is called before the first frame update
    void Start()
    {
        resetTime = time;       //asignamos que resetee el valor

    }

    // Update is called once per frame
    void Update()
    {
        time = time - 1 * Time.deltaTime;                    //restar� 1u/s
        if (time < 0)                                        //si es inferior a 0 haz lo siguiente
        {
            number = Random.Range(0, Pops.Length);           //hacemos un bingo
            Instantiate(Pops[number], waypoint[number]);     //mueve el objetivo al punto indicado. Se indicaran en Unity y donde
            time = resetTime;                               //una vez hecho resetea la cuenta
        }
   
    }

}
