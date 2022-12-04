using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonUI : MonoBehaviour
{
  
   public void GameStart()
    {
        SceneManager.LoadScene("Level1Xavi");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenuXavi");
    }

}
