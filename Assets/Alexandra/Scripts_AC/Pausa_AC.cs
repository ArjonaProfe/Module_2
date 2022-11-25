using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausa_AC : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))                //Al pulsar la tecla que se accione
        {
            PausarJuego();
        }
    }
    public void PausarJuego()
    {
        if (Time.timeScale == 1)                //se refiere a la escala con la que ocurre el tiempo. Si est� a 1, vu�lvelo 0, se pausar�
        {
            Time.timeScale = 0;                 //si ya est� pausado rein�cialo
        }
        else
        {
            Time.timeScale = 1;                 //si no est� pausado que es� activado el tiempo
        }
    }
}
