using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerEvent : MonoBehaviour
{

    public Text textbox;            // Variable donde se guardará el texto que se quiere mostrar
    public string message;          // Variable donde se guardará la cadena de texto que se enviará a 'textBox'

    private void OnTriggerEnter2D(Collider2D collision)     // Función que se llama automáticamente cuando un objeto con colisión 2D entra en el trigger 2D que tenga este objeto
    {

        if (collision.tag == "Player")                  // Si el objeto que colisiona tiene el tag 'Player'
        {   
            textbox.text = message;                     // Muestra la cadena de texto 'message' en el texto 'textBox'
            Debug.Log(message);                         // Saca el resultado por consola para comprobar fácilmente que funciona
        }
    }
}
