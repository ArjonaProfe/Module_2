using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExitLevelGerard : MonoBehaviour
{

    public ScoreManagerGerard smg;
    private float secsToExit = 5f;
    public Text done;
    public Text finalScoreText;
    private float finalScore;


    void Start()
    {
        smg = FindObjectOfType<ScoreManagerGerard>();
        secsToExit = 5f;
    }


    void Update()
    {
        if (smg.enemiesNumber == 0)
        {
            finalScore = smg.score;
            finalScoreText.text = "Final Score: \n" + finalScore.ToString();
            secsToExit = secsToExit - 1 * Time.deltaTime;
            done.text = "Done! \n" + secsToExit.ToString("0");
            SaveHihgScoresLevel();

            if (secsToExit <= 0)
            { 
            SceneManager.LoadScene("Floor Selection NTRM");
            }
        }
    }

    void SaveHihgScoresLevel()
    {
        if (SceneManager.GetActiveScene().name == "Tutorial NTRM" && smg.score > PlayerPrefs.GetInt("HighscoreTutorial"))
        {
            PlayerPrefs.SetInt("HighscoreTutorial", smg.score);
        }

        if (SceneManager.GetActiveScene().name == "Level 1 NTRM" && smg.score > PlayerPrefs.GetInt("HighscoreLevelOne"))
        {
            PlayerPrefs.SetInt("HighscoreLevelOne", smg.score);
        }

        if (SceneManager.GetActiveScene().name == "Level 2 NTRM" && smg.score > PlayerPrefs.GetInt("HighscoreLevelTwo"))
        {
            PlayerPrefs.SetInt("HighscoreLevelTwo", smg.score);
        }

        if (SceneManager.GetActiveScene().name == "Level 3 NTRM" && smg.score > PlayerPrefs.GetInt("HighscoreLevelThree"))
        {
            PlayerPrefs.SetInt("HighscoreLevelThree", smg.score);
        }
    }



}
