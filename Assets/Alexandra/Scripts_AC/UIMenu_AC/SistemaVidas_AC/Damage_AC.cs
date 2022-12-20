using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;



public class Damage_AC : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameControl_AC.health -= 1;
    }

}
