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
        if (PlayerPrefs.GetFloat("SavedData") == 1 )           // Si existen datos de guardado, se cargan, pero si no es el caso se cogen los datos por defecto
        {
            LoadData();
        }
    }


    public static void SaveData()
    {
        PlayerPrefs.SetFloat("SavedData", savedData = 1);
    }

    public static void LoadData()
    {
        tutorialSucces = PlayerPrefs.GetString("tutorialSucces", "No");
        levelOneSucces = PlayerPrefs.GetString("levelOneSucces", "No");
        levelTwoSucces = PlayerPrefs.GetString("levelTwoSucces", "No");
        levelThreeSucces = PlayerPrefs.GetString("levelThreeSucces", "No");
        levelOneTimerSucces = PlayerPrefs.GetString("levelOneTimerSucces", "No");
        levelTwoTimerSucces = PlayerPrefs.GetString("levelTwoTimerSucces", "No");
        levelThreeTimerSucces = PlayerPrefs.GetString("levelThreeTimerSucces", "No");
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
