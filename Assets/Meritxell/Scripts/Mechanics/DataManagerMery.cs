using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class DataManagerMery : MonoBehaviour        // Gestión de datos guardados
{
    public static int lives;                        // Los datos guardados en health y collectibles
    public static int collected;
    public static int healthPoints;
    
    public  static float savedData;                 // Esencialmente un bool para indicar si hay datos guardados
    
    public  static int savedCollec;                 // Datos de guardado
    public  static int savedLives;

    public static string isDeath;                   // Bool para diferenciar si el nivel se está reiniciando por una muerte
    public static string levelCleared;              // Bool para identificar si el usuario ha completado o no el primer nivel

    public void Start()
    {
        if(PlayerPrefs.GetFloat("SavedData") == 1 && isDeath == "No")           // Si existen datos de guardado, se cargan, pero si no es el caso se cogen los datos por defecto
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
        if (Input.GetKeyDown(KeyCode.Z))           // Para testing. Pulsar Z debería eliminar los datos guardados (no funciona)
        {
            Debug.Log("Tecla pulsada");
            DeleteData();
        }
    }

    public static void SaveData()
    {
        lives = HealthCounterMery.lives;                           // Se cogen los datos de los contadores para guardar
        collected = CollectibleCounterMery.collected;

        PlayerPrefs.SetInt("Lives", lives);                        // Se crea el int donde se guardan los datos
        PlayerPrefs.SetInt("Collectibles", collected);

        PlayerPrefs.SetFloat("SavedData", savedData = 1);          // Se especifica que existen datos de guardado

        PlayerPrefs.SetString("Death", isDeath = "No");            // Si se han guardado datos (lo que solo ocurre al final de una fase), al reiniciar el nivel no ha sido por una muerte y por tanto no se reinician los datos

        Debug.Log("Saving");

        savedLives = lives;                                        // Los datos de guardados equivalen a los valores cogidos
        savedCollec = collected;
    }

    public static void SaveProgress()
    {
        PlayerPrefs.SetString("LevelCleared", levelCleared = "Yes");     // Al terminar el primer nivel, levelCleared se guarda como YES
    }

    public static void LoadData()
    {  
        savedLives = PlayerPrefs.GetInt("Lives");                        // Coge los int con los datos
        savedCollec = PlayerPrefs.GetInt("Collectibles");

        savedData = PlayerPrefs.GetFloat("SavedData", 0);                // Se establece que el valor por defecto is 0

        isDeath = PlayerPrefs.GetString("Death", "No");                  // Los valores por defecto si no se especifica cambiarlos
        levelCleared = PlayerPrefs.GetString("LevelCleared", "No");

        Debug.Log("Loading");

        HealthCounterMery.lives = savedLives;                            // Los valores guardados se aplican a los valores estáticos que se reflejan en el juego
        CollectibleCounterMery.collected = savedCollec;
    }

    public static void DeleteData()
    {
        PlayerPrefs.DeleteAll();                                         // Eliminar los datos de guardado

        PlayerPrefs.SetFloat("SavedData", savedData = 0);                // Ponemos los valores donde pertenece (aunque tienen default, testear si vuelven solos)
        PlayerPrefs.SetString("LevelCleared", levelCleared = "No");
        PlayerPrefs.SetString("Death", isDeath = "No");

        Debug.Log("Deleting");
     
    }
}
