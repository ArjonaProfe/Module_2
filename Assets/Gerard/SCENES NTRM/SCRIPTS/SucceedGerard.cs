using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SucceedGerard : MonoBehaviour
{

    public bool succeedLevel;    // seteamos el boleano succeedLevel por tal de confirmar si hemos pasado el level o no.
    public float scoreToScuceed;  //seteamos el valor del score que queremos que sea el minimo necesario para pasar el nivel.

    public ScoreManagerGerard smg;   // cogemos el script ScoreManagerGerard para poder coger valores de este.

    void Start()
    {
        succeedLevel = false;       //hacemos que desde el principio del objeto que contenga el script ponga el boleano suceedLevel en falso, pues cada vez que empecemos level tiene que ser falso.
    }


    void Update()
    {
        smg = FindObjectOfType<ScoreManagerGerard>();    //buscamos en el script "ScoreManagerGerard" para sacar el score y poder darle al parametro ScoreToSucced un valor true en caso de tener más de la puntuación mínima o igual a la minima
        if (smg.score >= scoreToScuceed)
        {
            succeedLevel = true;
        }
    }
}
