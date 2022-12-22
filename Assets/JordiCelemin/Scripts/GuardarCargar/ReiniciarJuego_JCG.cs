using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReiniciarJuego_JCG : MonoBehaviour
{
    public string PlataformScene_JCG; //script que te lleva a plataformscene_jcg

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))  //si te sale cargar la partida esto carga la partida
        {
            LoadScene();
        }
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(PlataformScene_JCG);  //cuando cargas la partida recarga la escena PlataformScene_jcg
    }


}
