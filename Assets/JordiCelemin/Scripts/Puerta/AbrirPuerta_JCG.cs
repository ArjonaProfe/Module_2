using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirPuerta_JCG : MonoBehaviour
{
    public static int llave;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")       //cuando colisione con Player tag se añade llave +1
        {
           
            llave = 1;
        }

    }
    
}
