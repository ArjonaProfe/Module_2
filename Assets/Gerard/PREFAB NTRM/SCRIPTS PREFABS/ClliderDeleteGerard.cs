using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClliderDeleteGerard : MonoBehaviour
{

    public Collider2D colliderShift;
    public float setTimer = 3f;

    void Start()
    {
        colliderShift = GetComponent<Collider2D>();
    }


    void Update()
    {
        if (Input.GetButtonDown("Fire3"))
        {
            colliderShift.enabled = false;

        }
        else colliderShift.enabled = true;
    }
}
