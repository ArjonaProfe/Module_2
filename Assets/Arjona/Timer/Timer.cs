using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    public Text clock;                          //  Aqu� se referenciar� el texto del canvas donde se mostrar� el tiempo de partida
    private float seconds;                      //  Aqu� se guardar� el resultado de la cuenta que calcula el tiempo de partida 
  

    // Update is called once per frame
    void Update()
    {
       seconds = seconds + 1 * Time.deltaTime;  // Cada segundo que pasa se suma 1 unidad a la variable 'seconds'
        
       int sec = Mathf.RoundToInt(seconds);     // Para evitar que el tiempo salga con decimales, se declara una nueva variable entera y se redondea el valor de 'seconds' 

        clock.text = sec.ToString();            // Se convierte la variable entera 'sec' a string para poder mostrarla en el texto 'clock'
    }
}
