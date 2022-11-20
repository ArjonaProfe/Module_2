using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)     //Al entrar en el trigger2D
    {
        Destroy(collision.gameObject);                      //Se destruirá el otro objeto
    }
}
