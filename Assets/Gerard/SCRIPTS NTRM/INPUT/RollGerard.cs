using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollGerard : MonoBehaviour
{

    public bool flipped;                        // hago publico el boleano flipped para hacer el roll en la direcci�n correcta.
    public float xRoll;                        // hago publico el parametro xRoll para a�adirle velocidad al Roll.
    private Rigidbody2D rb;                   // hago privado la asiganci�n de RigidBody2D a rb.
    public bool rollCD;                     // hago publico el boleano rollCD para poder ponerle un CD.

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();                // le a�ado del rigidbody2D al objeto que pongamos en "rb".
    }

   

    void Update()
    {
        if (Input.GetButton("Fire3"))
        {
            rb.AddForce(transform.right * xRoll);
            Debug.Log("Fire3");
        }
    }
}
