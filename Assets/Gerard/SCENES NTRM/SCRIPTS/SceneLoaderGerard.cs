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


    public Button TButton;
    public Button L1Button;
    public Button L2Button;
    public Button L3Button;

    public void Start()
    {

        if (DataManagerGerard.tutorialSucces == "No")            // Si el primer nivel no se ha superado, el botón no se puede usar
        {
            L1Button.interactable = false;
        }
        else 
        {
            L1Button.interactable = true;
        }
        if (DataManagerGerard.levelOneSucces == "No")
        {
            L2Button.interactable = false;
        }
        else 
        {
            L2Button.interactable = true;
        }
        if (DataManagerGerard.levelTwoSucces == "No")
        {
            L3Button.interactable = false;
        }
        else
        {
            L3Button.interactable = true;
        }

    }




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
