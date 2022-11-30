using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvGoalOscar : MonoBehaviour
{
    public LevelManagerOscar LvMan;

    // Start is called before the first frame update
    void Start()
    {
        LvMan = FindObjectOfType<LevelManagerOscar>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            LvMan.LevelClear();
        }
    }
}
