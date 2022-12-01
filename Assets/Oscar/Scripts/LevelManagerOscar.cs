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

    private void Start()
    {
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

    public void Update()
    {
        if(ShardLabel != null)
        {
            ShardLabel.text = "Cx" + Shards.ToString();
        }
        
        //To menu if player dies
        if(Player == null) { GoToScene(43); }
    }

    public void GoToScene(int ID)
    {
        SceneManager.LoadScene(ID);
    }

    public void LevelClear()
    {
        LvStats[SceneID].LvClear = true;
        SceneManager.LoadScene(43);
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
}
