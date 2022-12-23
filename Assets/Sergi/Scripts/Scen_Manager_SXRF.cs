using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scen_Manager_SXRF : MonoBehaviour
{
    public string SceneName;        // Variable para guardar la escena

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))   // Pulsando la tecla Enter
        {
            LoadScene();                        //se carga la escena
        }
    }
    public void LoadScene()                     // Funcion Load scene
    {
        SceneManager.LoadScene(SceneName);      // Carga la Scene X
    }
}
