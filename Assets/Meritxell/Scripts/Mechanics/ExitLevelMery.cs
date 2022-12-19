using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

public class ExitLevelMery : MonoBehaviour           // Script de salida de nivel
{
    public Text successText;

    private void Start()
    {
        
        successText.enabled = false;
    }

    public void OnTriggerEnter2D(Collider2D other)              // Al colisionar con el trigger
    {
        if (other.CompareTag("Player"))     // Si el objeto tiene el tag player y no es un trigger
        {
            successText.enabled = true;
            Invoke("LoadScene", 3f);
            PauseManagerMery.isPaused = true;
        }
    }

    void LoadScene()
    {
    
        if (SceneManager.GetActiveScene().name == "Level1Mery")
        {
            Debug.Log("Saving");
            SceneManager.LoadScene("LevelsMenuMery");             // Cargar el menú y resetear los puntos de salud
            HealthCounterMery.ResetHealth();
            DataManagerMery.SaveData();
            DataManagerMery.SaveProgress();
        }
        if (SceneManager.GetActiveScene().name == "Level2Mery")
        {
            SceneManager.LoadScene("FinalSceneMery");
            HealthCounterMery.ResetHealth();
            DataManagerMery.SaveData();
            DataManagerMery.SaveProgress();
        }

        PauseManagerMery.isPaused = false;
    }
}

