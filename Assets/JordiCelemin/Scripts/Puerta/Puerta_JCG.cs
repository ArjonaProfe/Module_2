using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta_JCG : MonoBehaviour
{
    
    public GameObject key;
    public GameObject btnPuerta;

    
    private void Start()
    {
        key.SetActive(true);
       
        //btnPuerta.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("key"))
        {
            AbrirPuerta_JCG.llave += 1;
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag.Equals("door") && AbrirPuerta_JCG.llave == 0)   //cuando door el tag tiene que tener una condicion si no hay llave va aparecer que no hay llave y cuando tenga la llave si se acerca si que se vera la llave.
        {
            key.SetActive(false);
        }
        if (collision.tag.Equals("door") && AbrirPuerta_JCG.llave == 1)  
        {
            key.SetActive(true);
            btnPuerta.SetActive(true);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        key.SetActive(true);
        btnPuerta.SetActive(false);
    }
}
