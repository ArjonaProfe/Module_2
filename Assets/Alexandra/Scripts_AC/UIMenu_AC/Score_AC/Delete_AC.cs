using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete_AC : MonoBehaviour      //script para eliminar datos guardados
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Delete))   // Si se pulsa 'Suprimir'
        {
            PlayerPrefs.DeleteAll();            // Elimina los datos guardados en 'PlayerPrefbs'
            Debug.Log("Delete");
        }
    }
}
