using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    public Text lifesTextbox;           // Aqu� se referenciar� el texto del canvas donde se mostrar�n las vidas restantes 
    private int lifes;                  // Aqu� se guardar� el n�mero de vidas que haya en el script 'LifeCounter'


    // Start is called before the first frame update
    void Start()
    {

        lifes = LifeCounter.lifes;                  // Se iguala la variable 'lifes' de este script al valor que haya guardado en la variable 'lifes' del script 'LifeCounter'
        lifesTextbox.text = lifes.ToString();       // El texto 'lifesTextbos' mostrar� el valor de la variable 'lifes'

        if (lifes < 0)                              // Si lifes es menor que cero
        {
            lifesTextbox.text = "HAS MORIO";        // Se mostrar� el mensaje 'HAS MORIO' por consola.
        }
    }
}
