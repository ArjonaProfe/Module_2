using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopRunEnemyGerard : MonoBehaviour
{

    public EnemyPatrolGerard epg;


     void Start()
    {
        epg = FindObjectOfType<EnemyPatrolGerard>();
    }


    void Update()
    {

        epg.stopRun = false;

    }
}
