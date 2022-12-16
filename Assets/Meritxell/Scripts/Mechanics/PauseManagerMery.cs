using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

public class PauseManagerMery : MonoBehaviour
{
    public static bool isPaused;
    public GameObject pausePanel;

    public void Start()
    {
        isPaused = false;
        pausePanel.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            ChangePause();
        }
    }

    public void ChangePause()
    {
        isPaused = !isPaused;                    // isPaused es igual al valor contrario por defecto, lo que significa verdadero 

        if (isPaused == true)
        {
            pausePanel.SetActive(true);          // Activar y desactivar el panel y pausar y despausar el tiempo
            Time.timeScale = 0f;
        }
        else
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void Continue()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene("Level1Mery");
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainmenuMery");
        Time.timeScale = 1f;
        isPaused = false;
    }
}
