using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SceneLoaderGerard : MonoBehaviour
{

    public string SceneName1;      //guardamos una variable para cada nombre de Escena.
    public string SceneName2;
    public string SceneName3;
    public string SceneName4;
    public string SceneName5;





    public void LoadScene1()
    {
        SceneManager.LoadScene(SceneName1);          //Carga la Escena "------"
    }

    public void LoadScene2()
    {
        SceneManager.LoadScene(SceneName2);
    }

    public void LoadScene3()
    {
        SceneManager.LoadScene(SceneName3);
    }

    public void LoadScene4()
    {
        SceneManager.LoadScene(SceneName4);
    }

    public void LoadScene5()
    {
        SceneManager.LoadScene(SceneName5);

    }

    public void QuitGame()

    {
        Application.Quit();         // Cerrar la aplicación.
    }

}
