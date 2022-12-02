using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderMery : MonoBehaviour
{
    public string SceneName;                    // Variable donde guardaremos el nombre de la escena a cargar 
    public string Sandbox;                    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))   // Si se pulsa la tecla 'Return'
        {
            LoadScene();                        // Se llama a la función 'LoadScene()'
        }
    }
    public void LoadScene()                      // Función extern 'LoadScene()'
    {
        SceneManager.LoadScene(SceneName);      // Carga la escena 'SceneName'
    }
    public void LoadScene2()
    {
        SceneManager.LoadScene("Sandbox");      // Recuerda "" es necesario para los nombres de scene
    }
}
