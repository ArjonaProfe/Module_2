using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoolStopRunRangedGerard : MonoBehaviour
{

    public EnemyPatrolRangedGerard eprg;



    private void Start()
    {
        eprg = FindObjectOfType<EnemyPatrolRangedGerard>();
    }




    void Update()
    {
        eprg.stopRun = false;
    }
}
