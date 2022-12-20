using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;



public class Damage_AC : MonoBehaviour      //script de daño
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")                //el objeto que tenga el Tag de Enemy será el que haga daño
        GameControl_AC.health -= 1;             //resta 1 punto de vida
        Debug.Log("ouch");
    }

}
