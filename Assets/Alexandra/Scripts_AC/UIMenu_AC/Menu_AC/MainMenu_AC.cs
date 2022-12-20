using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MainMenu_AC : MonoBehaviour    //Script para cambio de escena
{
    public void EscenaMenu()                         //pública para que el usuario pueda interactuar
    {
        SceneManager.LoadScene("MainMenuScene_AC");       //el nombre exacto que le hemos puesto a la escena creada
    }
    public void EscenaJuego()                        //pública para que el usuario pueda interactuar
    {
        SceneManager.LoadScene("Play_AC");         //el nombre exacto que le hemos puesto a la escena creada
    }

    public void Salir()                           //variable para poder salir del juego. Pública para que el usuario pueda interactuar
    {
        Application.Quit();                       //Función para salir del juego
    }
}
