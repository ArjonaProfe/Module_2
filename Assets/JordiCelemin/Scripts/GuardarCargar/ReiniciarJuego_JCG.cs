using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReiniciarJuego_JCG : MonoBehaviour
{
    public string PlataformScene_JCG;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            LoadScene();
        }
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(PlataformScene_JCG);
    }


}
