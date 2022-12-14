using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelsMenuMery : MonoBehaviour
{
    public void Level1()
    {
        SceneManager.LoadScene("Level1Mery");
    }

    public void Level2()
    {
        SceneManager.LoadScene("Level2Mery");
    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenuMery");
    }
}
