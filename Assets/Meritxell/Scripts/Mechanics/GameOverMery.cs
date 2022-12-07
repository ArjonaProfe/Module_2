using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMery : MonoBehaviour      // Script en control de la pantalla de Game Over
{
    void Update()           
    {
        if (Input.anyKey)                              // Si se pulsa cualquier tecla
        {
            SceneManager.LoadScene("SandboxMery");     // Se carga la escena (nota: esto llevará de vuelta al menú principal cuando se implemente)
            HealthCounterMery.ResetLives();            // Se llama a ResetLives en el contador
        }
    }
}
