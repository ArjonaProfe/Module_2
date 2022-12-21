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

    // Update is called once per frame
    void Update()
    {
        if (smg.enemiesNumber == 0)
        {
            finalScore = smg.score;
            finalScoreText.text = "Final Score: \n" + finalScore.ToString();
            secsToExit = secsToExit - 1 * Time.deltaTime;
            done.text = "Done! \n" + secsToExit.ToString("0");

            if (secsToExit <= 0)
            { 
            SceneManager.LoadScene("Floor Selection NTRM");
            }
        }
    }

    void LoadScene()
    {

        if (SceneManager.GetActiveScene().name == "Tutorial NTRM")
        {
            SceneManager.LoadScene("Floor Selection NTRM");
            DataManagerGerard.SaveData();
            DataManagerGerard.TutorialProgress();

        }
        if (SceneManager.GetActiveScene().name == "Level 1 NTRM")
        {
            SceneManager.LoadScene("Floor Selection NTRM");
            DataManagerGerard.SaveData();
            DataManagerGerard.LevelOneProgress();
        }
        if (SceneManager.GetActiveScene().name == "Level 2 NTRM")
        {
            SceneManager.LoadScene("Floor Selection NTRM");
            DataManagerGerard.SaveData();
            DataManagerGerard.LevelTwoProgress();
        }
        if (SceneManager.GetActiveScene().name == "Level 3 NTRM")
        {
            SceneManager.LoadScene("Floor Selection NTRM");
            DataManagerGerard.SaveData();
            DataManagerGerard.LevelThreeProgress();
        }

    }

}
