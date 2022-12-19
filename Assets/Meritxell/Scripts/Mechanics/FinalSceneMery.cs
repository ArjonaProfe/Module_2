using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class FinalSceneMery : MonoBehaviour      // Script en control de la pantalla de Game Over
{
    public void Start()
    {
        HealthCounterMery.ResetLives();            // Se llama a ResetLives en el contador
        DataManagerMery.SaveData();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenuMery");     // Se carga la escena (nota: esto llevará de vuelta al menú principal cuando se implemente)

    }
}
