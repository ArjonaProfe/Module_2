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
        public List<bool> Gems;
    }
    public List<Collectibles> LvGems;

    private void Start()
    {
        if (CollectLabel != null)
        {
            int Counter = 0;
            for (int i = 0; i < LvGems[SceneID].Gems.Count; i++)
            {
                if (LvGems[SceneID].Gems[i] == true) { Counter += 1; }
            }
            CollectLabel.text = "Gx" + Counter.ToString() + "/" + LvGems[SceneID].Gems.Count;
        }
    }

    public void Update()
    {
        if(ShardLabel != null)
        {
            ShardLabel.text = "Cx" + Shards.ToString();
        }
        
        //To menu if player dies
        if(Player == null) { GoToScene(2); }
    }

    public void GoToScene(int ID)
    {
        SceneManager.LoadScene(ID);
    }

    public void LevelClear()
    {
        SceneManager.LoadScene(2);
    }

    public void CollectGem(int ID)
    {
        LvGems[SceneID].Gems[ID] = true;

        //Updating the UI
        if (CollectLabel != null)
        {
            int Counter = 0;
            for (int i = 0; i < LvGems[SceneID].Gems.Count; i++)
            {
                if (LvGems[SceneID].Gems[i] == true) { Counter += 1; }
            }
            CollectLabel.text = "Gx" + Counter.ToString() + "/" + LvGems[SceneID].Gems.Count;
        }
    }
}
