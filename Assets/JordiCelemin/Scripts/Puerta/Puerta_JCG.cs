using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta_JCG : MonoBehaviour
{
    
    public GameObject key;
    public GameObject Puerta;
    
    private void Start()
    {
        key.SetActive(true);
        Puerta.SetActive(true);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Key"))
        {
            AbrirPuerta_JCG.llave = 1;
            Destroy(collision.gameObject);
        }
    }

    
}
