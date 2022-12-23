using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelsMenuMery : MonoBehaviour              // Menú de niveles
{
    public Button L2Button;       // Botón dirigiendo al segundo nivel

    public void Start()
    {
        DataManagerMery.LoadData();                          // Se cargan los datos guardados

        L2Button.interactable = false;

        /*if (DataManagerMery.levelCleared == "No")            // Si el primer nivel no se ha superado, el botón no se puede usar
        {
            L2Button.interactable = false;
        }
        else
        {
            L2Button.interactable = true;
        }*/
    }

    public void Level1()                                // Cargar nivel 1
    {
        DataManagerMery.LoadData();                          // Se cargan los datos guardados

        if (PlayerPrefs.GetFloat("SavedData") == 1)           // Si existen datos de guardado, se cargan, pero si no es el caso se cogen los datos por defecto
        {
            DataManagerMery.LoadData();
            SceneManager.LoadScene("Level1Mery");
            HealthCounterMery.ResetHealth();
        }
        else
        {
            SceneManager.LoadScene("Level1Mery");
            HealthCounterMery.ResetHealth();
            HealthCounterMery.ResetLives();
            CollectibleCounterMery.ResetCollectibles();
        }
    }

    /*public void Level2()
    {
        if(DataManagerMery.levelCleared == "Yes")     // Cargar nivel dos (solo se puede usar si se ha superado el primer nivel)
        {
            SceneManager.LoadScene("Level2Mery");
        }

    }*/

    public void Back()                               // Regresar al menú principal
    {
        SceneManager.LoadScene("MainMenuMery");
    }
}
