using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class MainMenuMery : MonoBehaviour                 // Script del main menu
{
      public void Continue()                              // Cargar la escena Level1. Esto se cambiará al selector de niveles. Incorporar guardado
      {
             SceneManager.LoadScene("Level1Mery");
      }

      public void NewGame()                                // Cargar Level1. Resetea las vidas y los coleccionables
      {
             SceneManager.LoadScene("Level1Mery");
             CollectibleCounterMery.ResetCollectibles();
             HealthCounterMery.ResetLives();
      }

      public void Quit()                 // Salir
      {
              Application.Quit();
              Debug.Log("Exit");
      }
}
