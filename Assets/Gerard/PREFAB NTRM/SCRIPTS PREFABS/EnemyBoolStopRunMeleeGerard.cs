using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoolStopRunMeleeGerard : MonoBehaviour
{

    public EnemyPatrolGerard epg;



    private void Start()
    {
        epg = FindObjectOfType<EnemyPatrolGerard>();
    }




    void Update()
    {
        epg.stopRun = false;
    }
}
