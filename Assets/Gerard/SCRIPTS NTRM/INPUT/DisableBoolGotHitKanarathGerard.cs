using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableBoolGotHitKanarathGerard : MonoBehaviour
{
    public bool gotHit;
    public Animator an;


    void Update()
    {
        {
            gotHit = false;
            an.SetBool("GotHit", gotHit);
        }
    }
}
