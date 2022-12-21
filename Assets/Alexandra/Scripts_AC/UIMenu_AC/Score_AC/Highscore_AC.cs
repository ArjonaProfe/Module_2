using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscore_AC : MonoBehaviour
{
    public float Score;
    public float highscore;
    public Text scoretext;
    public Text highscoretext;

    public void AddScore()
    {
        Score++;                    //guarda la puntuación
    }

    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetFloat("Highscore");
    }

    // Update is called once per frame
    void Update()
    {
        scoretext.text = Score.ToString();              //muestra el score en pantalla y el highscore
        if (Score > highscore)
        {
            PlayerPrefs.SetFloat("Highscore", Score);
            Debug.Log("savepoint");
        }
    }
}
