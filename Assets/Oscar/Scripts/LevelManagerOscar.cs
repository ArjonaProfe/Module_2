using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagerOscar : MonoBehaviour
{
    public void GoToScene(int ID)
    {
        SceneManager.LoadScene(ID);
    }
}
