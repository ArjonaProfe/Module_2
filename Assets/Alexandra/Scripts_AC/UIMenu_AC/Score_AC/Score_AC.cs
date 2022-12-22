using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UI;

public class Score_AC : MonoBehaviour               //script score de la partida que se incrementa con el tiempo
{
    public Text Text;
    public Text scoreText;
    float score;
    int highscore;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;                                      //score al inicio
    }

    // Update is called once per frame
    void Update()
    {
        score += Time.deltaTime * 1;                    //incrementar 1punto acorde con el tiempo del PC
        highscore = (int)score;                         //sale en pantalla en score on going
        scoreText.text = highscore.ToString();          //en pantalla
        if (PlayerPrefs.GetInt("score") <= highscore)
            PlayerPrefs.SetInt("score", highscore);
    }
    public void highscorefun ()
    {
        Text.text = PlayerPrefs.GetInt("score").ToString(); //muestra en pantalla el score
    }
}
