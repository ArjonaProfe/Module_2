using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeAttackTIMERGerard : MonoBehaviour
{
    public Text timer;                          //  Aqu� se referenciar� el texto del canvas donde se mostrar� el tiempo de partida
    private float seconds;                      //  Aqu� se guardar� el resultado de la cuenta que calcula el tiempo de partida 



    void Update()
    {
        seconds = seconds + 1 * Time.deltaTime;         // Cada segundo que pasa se suma 1 unidad a la variable 'seconds'
        timer.text = "Timer: \n" + seconds.ToString("00:00.00");                 // Se convierte la variable entera 'sec' a string para poder mostrarla en el texto 'clock'
    }
}
