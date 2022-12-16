using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class DataManagerMery : MonoBehaviour
{
    public static int lives;
    public static int collected;
    public static int healthPoints;
    
    public  static float savedData;
    public  static int savedCollec;
    public  static int savedLives;

    public static string isDeath;
    public static string levelCleared;

    public void Start()
    {
        if(PlayerPrefs.GetFloat("SavedData") == 1 && isDeath == "No")
        {
            LoadData();
        }
        else
        {
            lives = HealthCounterMery.lives;
            collected = CollectibleCounterMery.collected;
            healthPoints = HealthCounterMery.healthPoints;
        }

    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            DeleteData();
        }
    }

    public static void SaveData()
    {
        lives = HealthCounterMery.lives;
        collected = CollectibleCounterMery.collected;

        PlayerPrefs.SetInt("Lives", lives);
        PlayerPrefs.SetInt("Collectibles", collected);
        PlayerPrefs.SetFloat("SavedData", savedData = 1);
        PlayerPrefs.SetString("Death", isDeath = "No");
        Debug.Log("Saving");

        savedLives = lives;
        savedCollec = collected;
    }

    public static void SaveProgress()
    {
        PlayerPrefs.SetString("LevelCleared", levelCleared = "Yes");
    }

    public static void LoadData()
    {  
        savedLives = PlayerPrefs.GetInt("Lives");
        savedCollec = PlayerPrefs.GetInt("Collectibles");
        savedData = PlayerPrefs.GetFloat("SavedData", 0);
        isDeath = PlayerPrefs.GetString("Death", "No");
        levelCleared = PlayerPrefs.GetString("LevelCleared", "No");
        Debug.Log("Loading");

        HealthCounterMery.lives = savedLives;
        CollectibleCounterMery.collected = savedCollec;
    }

    public static void DeleteData()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetFloat("SavedData", savedData = 0);
        PlayerPrefs.SetString("LevelCleared", levelCleared = "No");
        PlayerPrefs.SetString("Death", isDeath = "No");

        Debug.Log("Deleting");
     
    }
}
