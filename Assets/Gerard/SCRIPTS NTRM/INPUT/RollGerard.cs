using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollGerard : MonoBehaviour
{

    public bool flipped;                        // hago publico el boleano flipped para hacer el roll en la dirección correcta.
    public float xRoll;                        // hago publico el parametro xRoll para añadirle velocidad al Roll.
    private Rigidbody2D rb;                   // hago privado la asiganción de RigidBody2D a rb.
    private float xMovement;                 // hago privado el parametro xMovement para coger los datos luego.
    public bool rollCD;                     // hago publico el boleano rollCD para poder ponerle un CD.

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();                // le añado del rigidbody2D al objeto que pongamos en "rb".
    }

   

    void Update()
    {
        xMovement = Input.GetAxisRaw("Fire3");                                 // se asigna el valor del "Fire3" a la variable xMovement.
        rb.velocity = new Vector2(xMovement * xRoll, rb.velocity.y);           // al valor "velocity" del rigidbody 2d "rb" se le asigna el valor en X : xMovement multiplicado por xRoll y se le deja en Y el valor que tenga.
    }
}
