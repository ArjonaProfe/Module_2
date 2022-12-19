using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public class AbrirPuerta_JCG : MonoBehaviour
{
    public static int llave;
    public GameObject llavecol;
    private void Start()
    {
        //llave = llavecol.GetComponent<int>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
       

        if (collision.gameObject.tag == "Player")       //cuando colisione con Player tag se añade llave +1
        {          
      
            llavecol.GetComponent<Image>().color = Color.white;

            llave = 1;
        }


    }
   



}
