using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadData : MonoBehaviour
{
    public int loadedNumber;  // variable donde se guardar� el n�mero cargado
    public Text textBox;      // texto para mostar el n�mero
 
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D)) // Si se pulsa 'D'
        {
            LoadNumber();                // Se llama a la funci�n 'LoadNumber()'
        }
    }

    public void LoadNumber()             // Funci�n 'LoadNumber()'
    {
        loadedNumber = PlayerPrefs.GetInt("savedNumber");  // Asigna a la variable 'loadedNumber' el valor de n�mero entero que haya en PlayerPrefs con el nombre 'savedNumber'
        textBox.text = loadedNumber.ToString();            // Muestra el valor guardado en el texto 'textbox'
    }
}
