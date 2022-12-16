using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainMenuMery : MonoBehaviour                 // Script del main menu
{
    public GameObject surePanel;

    private void Start()
    {
        surePanel.SetActive(false);
    }
    public void Continue()                              // Cargar la escena Level1. Esto se cambiará al selector de niveles. Incorporar guardado
      {
             SceneManager.LoadScene("Level1Mery");
             HealthCounterMery.ResetHealth();
      }

    public void Levels()
    {
        SceneManager.LoadScene("LevelsMenuMery");
    }

      public void NewGame()                                // Cargar Level1. Resetea las vidas y los coleccionables
      {
         surePanel.SetActive(true);
      }

    public void NGYes()
    {
        SceneManager.LoadScene("Level1Mery");
        CollectibleCounterMery.ResetCollectibles();
        HealthCounterMery.ResetLives();
        HealthCounterMery.ResetHealth();

        DataManagerMery.DeleteData();
    }

    public void NGNo()
    {
        surePanel.SetActive(false);
    }
      public void Quit()                 // Salir
      {
              Application.Quit();
              Debug.Log("Exit");
      }
}
