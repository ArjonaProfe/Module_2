using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    public Text lifesTextbox;           // Aquí se referenciará el texto del canvas donde se mostrarán las vidas restantes 
    private int lifes;                  // Aquí se guardará el número de vidas que haya en el script 'LifeCounter'


    // Start is called before the first frame update
    void Start()
    {

        lifes = LifeCounter.lifes;                  // Se iguala la variable 'lifes' de este script al valor que haya guardado en la variable 'lifes' del script 'LifeCounter'
        lifesTextbox.text = lifes.ToString();       // El texto 'lifesTextbos' mostrará el valor de la variable 'lifes'

        if (lifes < 0)                              // Si lifes es menor que cero
        {
            lifesTextbox.text = "HAS MORIO";        // Se mostrará el mensaje 'HAS MORIO' por consola.
        }
    }
}
