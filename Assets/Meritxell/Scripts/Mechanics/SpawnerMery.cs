using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnerMery : MonoBehaviour    
{
    public GameObject player;
    public Transform levelSpawner;

    string sceneName;

    private void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
    }

    void Update()
    {
            if (sceneName == "Level1Mery" && GameObject.FindGameObjectsWithTag("Player") == null)       
            {
              Instantiate(player, levelSpawner.position, levelSpawner.rotation);
            }
        
    }
}
