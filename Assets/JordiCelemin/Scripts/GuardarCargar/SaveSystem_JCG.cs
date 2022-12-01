using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem_JCG : MonoBehaviour
{
    PlayerMovement_JCG playerMovement;

    private void Awake()
    {
        playerMovement = FindObjectOfType<PlayerMovement_JCG>();
    }
    public void SaveGame()
    {
        Vector2 playerPos = playerMovement.GetPosition();

        PlayerPrefs.SetFloat("posX", playerPos.x);
        PlayerPrefs.SetFloat("posY", playerPos.y);
    }
    public void LoadGame()
    {
        Vector2 playerPos = new Vector2(PlayerPrefs.GetFloat("posX"), PlayerPrefs.GetFloat("posY"));
        playerMovement.SetPosition(playerPos);
    }
}
