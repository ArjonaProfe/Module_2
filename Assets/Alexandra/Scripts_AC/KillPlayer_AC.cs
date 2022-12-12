using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer_AC : MonoBehaviour
{
    public string Respawn;                     //mencionamos que queremos que reaparezca el Player

   void OnTriggerEnter2D (Collider2D other) //la función trigger actúe
    {
        if (other.CompareTag("Player"))     //si el Player choca con el trigger mencionado antes haz lo siguiente
        {
            SceneManager.LoadScene("Play_AC"); //mencionamos que la escena se resetee si "choca"
        }

    }
}
