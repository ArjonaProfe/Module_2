using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManagerGerard : MonoBehaviour
{

    public Text scoreText;
    public Text highscoreText;
    public Text minusscoreText;
    public Text enemiesText;




    public int score = 0;
    public int highscore = 0;
    public int minusScore = 0;
    public int enemiesNumber;
    public int minimumScore;


    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore:", 0);
        scoreText.text = score.ToString() + "Actual Score:";
        highscoreText.text = "HighScore:\n" + highscore.ToString();
    }

 
    void Update()
    {

        enemiesText.text = "Enemies Left:\n" + enemiesNumber.ToString();
        scoreText.text = "Actual Score:\n"  + score.ToString();
        minusscoreText.text = "Minus Score:\n" + minusScore.ToString();
        Debug.Log(minusScore);

        if (highscore<score)
        {
            PlayerPrefs.SetInt("highscore" , score);
        }

    }
}
