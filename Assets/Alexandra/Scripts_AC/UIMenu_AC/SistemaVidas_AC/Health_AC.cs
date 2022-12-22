using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
        


public class Health_AC : MonoBehaviour      //script para ganar punto de vida
{
    private void OnTriggerEnter2D (Collider2D other)
    {
        GameControl_AC.health += 1;                 //sumamos un punto de vida al recoger objeto
    }

}
