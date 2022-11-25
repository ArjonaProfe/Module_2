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
        if (Time.timeScale == 1)                //se refiere a la escala con la que ocurre el tiempo. Si está a 1, vuélvelo 0, se pausará
        {
            Time.timeScale = 0;                 //si ya está pausado reinícialo
        }
        else
        {
            Time.timeScale = 1;                 //si no está pausado que esé activado el tiempo
        }
    }
}
