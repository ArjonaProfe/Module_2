using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionarPuerta_JCG : MonoBehaviour
{
    public GameObject Reiniciar;
    public Text GameOver;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Reiniciar.gameObject.SetActive(true); //cuando se muera salga reiniciar
        GameOver.enabled = true;
    }
   
}
