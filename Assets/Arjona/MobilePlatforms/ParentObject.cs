using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentObject : MonoBehaviour
{
    
    private void OnCollisionEnter2D(Collision2D collision)       // Cuando un collider 2D impacte contra el objeto que tenga este script
    {
        if (collision.gameObject.layer == 6)                     // Se compara el índice que tiene la layer de ese objeto para ver si es el 6   
        {
            transform.parent = collision.gameObject.transform;   // El objeto con índice de layer 6 se convertirá en el objeto padre en la jerarquía de Unity del objeto que contenga este script
        }
    }

    private void OnCollisionExit2D(Collision2D collision)         // Cuando un collider 2D deje de impactar contra el objeto que tenga este script
    {
        if (collision.gameObject.layer == 6)                      // Se compara el índice que tiene la layer de ese objeto para ver si es el 6   
        {
            transform.parent = null;                              // Se desparenta el objeto 
        }
    }
}
