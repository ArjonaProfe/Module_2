using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelsMenuMery : MonoBehaviour
{
    public Button L2Button;

    public void Start()
    {

        DataManagerMery.LoadData();

        if (DataManagerMery.levelCleared == "No")
        {
            L2Button.interactable = false;
        }
        else
        {
            L2Button.interactable = true;
        }
    }

    public void Level1()
    {
        SceneManager.LoadScene("Level1Mery");
    }

    public void Level2()
    {
        if(DataManagerMery.levelCleared == "Yes")
        {
            SceneManager.LoadScene("Level2Mery");
        }

    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenuMery");
    }
}
