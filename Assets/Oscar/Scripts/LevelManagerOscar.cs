using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManagerOscar : MonoBehaviour
{
    public GameObject Player;
    public static int Shards;
    public Text ShardLabel, CollectLabel;
    public int SceneID;
    [System.Serializable]
    public class Collectibles
    {
        public bool LvClear;
        public List<bool> Gems;
    }
    public List<Collectibles> LvStats;

    //Buttons for the menu
    public List<Button> LvButtons;
    public GameObject DelPanel;

    private void Awake()
    {
        LoadGame();
        if (CollectLabel != null)
        {
            int Counter = 0;
            for (int i = 0; i < LvStats[SceneID].Gems.Count; i++)
            {
                if (LvStats[SceneID].Gems[i] == true) { Counter += 1; }
            }
            CollectLabel.text = "Gx" + Counter.ToString() + "/" + LvStats[SceneID].Gems.Count;
        }
        if(DelPanel != null) { DelPanel.SetActive(false); }
    }

    public void Update()
    {
        //Show the coins you have on UI
        if(ShardLabel != null)
        {
            ShardLabel.text = "Cx" + Shards.ToString();
        }
        
        //To menu if player dies
        if(Player == null) { GoToScene(42); }

        //Save game with a key
        if (Input.GetKeyDown(KeyCode.Q)) { SaveGame(); }

        if(LvButtons.Count > 0)
        {
            for (int i = 0; i < LvButtons.Count; i++)
            {
                if(i == 0) { LvButtons[i].interactable = true; }
                else if(LvStats[i - 1].LvClear == true) { LvButtons[i].interactable = true; }
                else { LvButtons[i].interactable = false; }
            }
        }
    }

    public void GoToScene(int ID)
    {
        SceneManager.LoadScene(ID);
    }

    public void LevelClear()
    {
        LvStats[SceneID].LvClear = true;
        SaveGame();
        SceneManager.LoadScene(40);
    }

    public void CollectGem(int ID)
    {
        LvStats[SceneID].Gems[ID] = true;

        //Updating the UI
        if (CollectLabel != null)
        {
            int Counter = 0;
            for (int i = 0; i < LvStats[SceneID].Gems.Count; i++)
            {
                if (LvStats[SceneID].Gems[i] == true) { Counter += 1; }
            }
            CollectLabel.text = "Gx" + Counter.ToString() + "/" + LvStats[SceneID].Gems.Count;
        }
    }

    public void SaveGame()
    {
        PlayerPrefs.SetInt("CoinCount", Shards);
        for (int i = 0; i < LvStats.Count; i++)
        {
            PlayerPrefs.SetInt("Level" + i + "Clearnes", LvStats[i].LvClear ? 1 : 0);
            for (int u = 0; u < LvStats[i].Gems.Count; u++)
            {
                PlayerPrefs.SetInt("Level" + i + "Gem" + u + "Taken", LvStats[i].Gems[u] ? 1 : 0);
            }
        }
    }

    public void LoadGame()
    {
        Shards = PlayerPrefs.GetInt("CoinCount");
        for (int i = 0; i < LvStats.Count; i++)
        {
            LvStats[i].LvClear = PlayerPrefs.GetInt("Level" + i + "Clearnes") == 1 ? true : false;
            for (int u = 0; u < LvStats[i].Gems.Count; u++)
            {
                LvStats[i].Gems[u] = PlayerPrefs.GetInt("Level" + i + "Gem" + u + "Taken") == 1 ? true : false;
            }
        }
    }

    public void AskIfDelete()
    {
        DelPanel.SetActive(true);
    }
    public void RefuseToDelete()
    {
        DelPanel.SetActive(false);
    }

    public void DeleteGame()
    {
        PlayerPrefs.SetInt("CoinCount", 0);
        for (int i = 0; i < LvStats.Count; i++)
        {
            PlayerPrefs.SetInt("Level" + i + "Clearnes", 0);
            for (int u = 0; u < LvStats[i].Gems.Count; u++)
            {
                PlayerPrefs.SetInt("Level" + i + "Gem" + u + "Taken", 0);
            }
        }
        LoadGame();
        DelPanel.SetActive(false);
    }
}
