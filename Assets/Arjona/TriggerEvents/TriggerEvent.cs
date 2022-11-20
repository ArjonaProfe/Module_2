using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerEvent : MonoBehaviour
{

    public Text textbox;            // Variable donde se guardar� el texto que se quiere mostrar
    public string message;          // Variable donde se guardar� la cadena de texto que se enviar� a 'textBox'

    private void OnTriggerEnter2D(Collider2D collision)     // Funci�n que se llama autom�ticamente cuando un objeto con colisi�n 2D entra en el trigger 2D que tenga este objeto
    {

        if (collision.tag == "Player")                  // Si el objeto que colisiona tiene el tag 'Player'
        {   
            textbox.text = message;                     // Muestra la cadena de texto 'message' en el texto 'textBox'
            Debug.Log(message);                         // Saca el resultado por consola para comprobar f�cilmente que funciona
        }
    }
}
