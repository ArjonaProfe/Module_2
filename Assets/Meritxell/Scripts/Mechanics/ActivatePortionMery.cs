using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePortionMery : MonoBehaviour      // Script para activar y desactivar elementos de una lista
{
    public List<GameObject> List1;
    private Collider2D col;

    void OnTriggerOnEnter2D(Collider2D collider)
    {
        foreach (GameObject obj in List1)
        {
            obj.SetActive(true);
        }
        Debug.Log("Entra");
    }
}
