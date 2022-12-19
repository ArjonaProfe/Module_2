using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoolStopRunMeleeGerard : MonoBehaviour
{

    public Animator an;
    public bool stopRun;






    void Update()
    {
        stopRun = false;
        an.SetBool("GotHit", stopRun);
    }
}
