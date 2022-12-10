using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class MainMenuMery : MonoBehaviour
{
      public void Continue()
      {
             SceneManager.LoadScene("Level1Mery");
      }

      public void NewGame()
      {
             SceneManager.LoadScene("Level1Mery");
             CollectibleCounterMery.ResetCollectibles();
             HealthCounterMery.ResetLives();
      }

      public void Quit()
      {
              Application.Quit();
              Debug.Log("Exit");
      }
}
