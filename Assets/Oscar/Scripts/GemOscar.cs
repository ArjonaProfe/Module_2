using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemOscar : MonoBehaviour
{
    public LevelManagerOscar LvMan;
    public int ID;
    public Animator Anim;

    private void Start()
    {
        LvMan = FindObjectOfType<LevelManagerOscar>();
        if(LvMan.LvStats[LvMan.SceneID].Gems[ID] == true)
        {
            Anim.SetBool("Collected", true);
        }
    }

    private void OnEnable()
    {
        LvMan = FindObjectOfType<LevelManagerOscar>();
        if (LvMan.LvStats[LvMan.SceneID].Gems[ID] == true)
        {
            Anim.SetBool("Collected", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            LvMan.CollectGem(ID);
            Destroy(gameObject);
        }
    }
}
