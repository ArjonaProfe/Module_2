using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string SceneName;                    // Variable donde guardaremos el nombre de la escena a cargar 
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))   // Si se pulsa la tecla 'Return'
        {
            LoadScene();                        // Se llama a la funci�n 'LoadScene()'
        }
    }
   public void LoadScene()                      // Funci�n 'LoadScene()'
    {
        SceneManager.LoadScene(SceneName);      // Carga la escena 'SceneName'
    }
}
