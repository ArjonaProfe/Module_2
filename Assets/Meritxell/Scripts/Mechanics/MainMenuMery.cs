using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainMenuMery : MonoBehaviour                 // Script del main menu
{
    public GameObject surePanel;

    public void Continue()                              // Cargar la escena Level1. Falta incorporar guardado. Resetea la vida
    {
        DataManagerMery.LoadData();                          // Se cargan los datos guardados

        if (PlayerPrefs.GetFloat("SavedData") == 1)           // Si existen datos de guardado, se cargan, pero si no es el caso se cogen los datos por defecto
        {
            DataManagerMery.LoadData();
            SceneManager.LoadScene("LevelsMenuMery");
            HealthCounterMery.ResetHealth();
        }
        else
        {
            SceneManager.LoadScene("Level1Mery");
            HealthCounterMery.ResetHealth();
            HealthCounterMery.ResetLives();
            CollectibleCounterMery.ResetCollectibles();
        }
    }

    public void Levels()                                // Menú de niveles
    {
        SceneManager.LoadScene("LevelsMenuMery");
    }

    public void NewGame()                                // Carga el panel
    {
         surePanel.SetActive(true);
    }

    public void NGYes()                                 // Si se confirma, empezará una partida nueva sin datos de guardado
    {
        DataManagerMery.DeleteData();

        SceneManager.LoadScene("Level1Mery");
        HealthCounterMery.ResetHealth();
        HealthCounterMery.ResetLives();
        CollectibleCounterMery.ResetCollectibles();
    }

    public void NGNo()                                 // Si no, se cierra el panel
    {
         surePanel.SetActive(false);                    
    }

    public void Quit()                                // Salir (No funciona)
      {
          Application.Quit();
          Debug.Log("Exit");
      }
}
