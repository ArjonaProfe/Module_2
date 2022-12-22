using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta_JCG : MonoBehaviour
{
    
    public GameObject key;    //el objeto de la llave
    public GameObject Puerta;   // el objeto de la puerta
    
    private void Start()
    {
        key.SetActive(true);   //cuando empiece que se active la llave cuando la cojas
        Puerta.SetActive(true);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Key"))
        {
            AbrirPuerta_JCG.llave = 1;   // si colisiona el Player con el tag Key se queda en uno y se destruye
            Destroy(collision.gameObject);
        }

        
    }

    


}
