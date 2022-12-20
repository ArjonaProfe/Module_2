using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapaDestroy_AC : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entra");     //Detector de metales
        Destroy(other.gameObject);      //todo lo que entre muere
       
    }
}
