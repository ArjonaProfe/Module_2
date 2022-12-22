using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadScene_JCG : MonoBehaviour
{
    public string PlataformScene_JCG; //escena del juego

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            LoadScene();  //cargar el juego 
        }
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(PlataformScene_JCG);  //carga la escena elegida plataformScene
    }
}  
