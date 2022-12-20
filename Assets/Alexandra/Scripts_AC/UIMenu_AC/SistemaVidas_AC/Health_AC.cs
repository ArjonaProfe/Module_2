using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;                   //vamos a usar un texto con UI
using UnityEngine.SceneManagement;      //cargar escenas             


public class Health_AC : MonoBehaviour
{
    private void OnTriggerEnter2D (Collider2D other)
    {
        GameControl_AC.health += 1;        
    }

}
