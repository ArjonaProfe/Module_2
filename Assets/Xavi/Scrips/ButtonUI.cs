using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonUI : MonoBehaviour
{
    [SerializeField] private string Scene1 = "Scene1";

   public void NewGameButton()
    {
        SceneManager.LoadScene(Scene1);
    }
}
