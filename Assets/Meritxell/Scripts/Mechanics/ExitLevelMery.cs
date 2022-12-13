using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLevelMery : MonoBehaviour           // Script de salida de nivel
{
    public void OnTriggerEnter2D(Collider2D other)              // Al colisionar con el trigger
    {
        if (other.CompareTag("Player") && !other.isTrigger)     // Si el objeto tiene el tag player y no es un trigger
        {
            SceneManager.LoadScene("MainMenuMery");             // Cargar el menú y resetear los puntos de salud
            HealthCounterMery.ResetHealth();
        }
    }
}
