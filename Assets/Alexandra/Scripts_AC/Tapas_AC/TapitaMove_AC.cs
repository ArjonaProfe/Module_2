using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapitaMove_AC : MonoBehaviour
{
    public float speed;         //velocidad del objeto que indicaremos en Unity
    public GameObject Pop;      //en Unity indicaremos el objeto
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }


    void Movement()
    {
        transform.position += new Vector3(0, speed, 0)*Time.deltaTime;  //el objeto se va a mover en el eje y a la velocidad indicada según el tiempo de cada PC
               
    }
}
