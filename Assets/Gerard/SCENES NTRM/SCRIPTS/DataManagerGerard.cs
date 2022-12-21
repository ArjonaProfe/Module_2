using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManagerGerard : MonoBehaviour
{

    public static string tutorialSucces;
    public static string levelOneSucces;              // Bool para identificar si el usuario ha completado o no el nivel
    public static string levelTwoSucces;
    public static string levelThreeSucces;
    public static string levelOneTimerSucces;
    public static string levelTwoTimerSucces;
    public static string levelThreeTimerSucces;

    public static float savedData;

    void Start()
    {

    }


    public static void SaveData()
    {
        PlayerPrefs.SetFloat("SavedData", savedData = 1);
    }



    public static void TutorialProgress()
    {
        PlayerPrefs.SetString("tutorialSucces", tutorialSucces = "Yes");     // Al terminar el tutorial, levelCleared se guarda como YES
    }

    public static void LevelOneProgress()
    {
        PlayerPrefs.SetString("levelOneSucces", levelOneSucces = "Yes");    
    }

    public static void LevelTwoProgress()
    {
        PlayerPrefs.SetString("levelTwoSucces", levelTwoSucces = "Yes");    
    }

    public static void LevelThreeProgress()
    {
        PlayerPrefs.SetString("levelThreeSucces", levelThreeSucces = "Yes");
    }

    void Update()
    {
        
    }
}
