using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem_JCG : MonoBehaviour
{
    PlayerMovement_JCG playerMovement;
    VidaPlayer_JCG life;
    private void Awake()
    {
        playerMovement = FindObjectOfType<PlayerMovement_JCG>();  //buscar un objeto el cual es el playerscript
        life = FindObjectOfType<VidaPlayer_JCG>();
    }
    public void SaveGame()
    {
        Vector2 playerPos = playerMovement.GetPosition();
        int playerHealth = life.GetHearts();

        PlayerPrefs.SetFloat("posX", playerPos.x);
        PlayerPrefs.SetFloat("posY", playerPos.y);
        PlayerPrefs.SetInt("life", playerHealth);
       

    }
    public void LoadGame()
    {
        Vector2 playerPos = new Vector2(PlayerPrefs.GetFloat("posX"), PlayerPrefs.GetFloat("posY"));
        int playerHealth = PlayerPrefs.GetInt("life");
        playerMovement.SetPosition(playerPos);
        life.SetHealth(playerHealth);

    }
}
