using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadFloorSelectGerard : MonoBehaviour
{

    public Text tutorialHighscore;
    public Text levelOneHighscore;
    public Text levelTwoHighscore;
    public Text levelThreeHighscore;

    public int tutorialHS;
    public int levelOneHS;
    public int levelTwoHS;
    public int levelThreeHS;





    void Start()
    {
        tutorialHS = PlayerPrefs.GetInt("HighscoreTutorial");
        levelOneHS = PlayerPrefs.GetInt("HighscoreLevelOne");
        levelTwoHS = PlayerPrefs.GetInt("HighscoreLevelTwo");
        levelThreeHS = PlayerPrefs.GetInt("HighscoreLevelThree");
        LoadHighscores();

    }

    void LoadHighscores()
    {
        tutorialHighscore.text = tutorialHS.ToString("TUTORIAL:  " + tutorialHS);
        levelOneHighscore.text = levelOneHS.ToString("FLOOR 1:   " + levelOneHS);
        levelTwoHighscore.text = levelTwoHS.ToString("FLOOR 2:   " + levelTwoHS);
        levelThreeHighscore.text = levelThreeHS.ToString("FLOOR 3:   " + levelThreeHS);

    }



}
