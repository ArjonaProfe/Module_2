using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGerard : MonoBehaviour
{

    public int numberToSave;     //seteamos la variable númerica entera "numberToSave"
    public bool succeedLevel;        // seteamos el boleano "succeedLevel" para poder usarla como condición.

    public SucceedGerard scc;   // le asignamos scc al Script "SuccedGerard"


    void Update()
    {
        scc = FindObjectOfType<SucceedGerard>();    // cogemos el Script mentado por tal de conseguir información y parametros de este.
        succeedLevel = scc.succeedLevel;            //le otorgamos el valor de succeedLevel del script "SucceedLevelGerard" a al mismo SucceedLevel de este Script

        if (succeedLevel == true)               // si el boleano succed level es cierto, nos guarda la partida conforme hemos pasado el nivel en el que se pone este SCRIPT
        {
            SaveSession();                    // Se llama a la función 'SaveNumber()'
        }
    }


    public void SaveSession()                                 // Función 'SaveSession'
    {
        if (numberToSave > PlayerPrefs.GetInt("savedNumber"))  // si el numberToSave es mayor al numero ya guardado en el prefab "savedNumber" entonces guarda la variable más abajo nombrada.
        { 
        PlayerPrefs.SetInt("savedNumber", numberToSave);     // Guarda la variable 'numberToSave' en el prefab "savedNumber" 
        }
    }
}
