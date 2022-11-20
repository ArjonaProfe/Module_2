using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public int numberToSave;

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))     // Si se pulsa la tecla 'A'
        {
            SaveNumber();                    // Se llama a la funci�n 'SaveNumber()'
        }          
    }

    public void SaveNumber()                                 // Funci�n 'SavedNumber'
    {
        PlayerPrefs.SetInt("savedNumber", numberToSave);     // Guarda la variable 'numberToSave' en el prefab "savedNumber" 
    }
}
