using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveData_AC : MonoBehaviour        //script para guardar datos
{
    public int numberToSave;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))     // Si se pulsa la tecla 'S'
        {
            SaveNumber();                    // Se llama a la función 'SaveNumber()'
        }
    }

    public void SaveNumber()                                 // Función 'SavedNumber'
    {
        PlayerPrefs.SetInt("score", numberToSave);     // Guarda la variable 'numberToSave' en el prefab "savedNumber". Ponemos la etiqueta que le hemos asignado en el script score para que tome el dato de a´hí
        Debug.Log("Save");                     
    }
}