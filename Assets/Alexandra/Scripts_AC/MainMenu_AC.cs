using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_AC : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);   //Load the active scene
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene_AC");     //Go to Main Menu when clic
    }
    public void GoToLevel()
    {
        SceneManager.LoadScene("LevelScene_AC");        //Go to Level when clic
    }
    public void QuitGameu()
    {
        Application.Quit();                             //Quit Game
    }
}
