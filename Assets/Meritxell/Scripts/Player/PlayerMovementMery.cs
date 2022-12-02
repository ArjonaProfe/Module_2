using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovementMery : MonoBehaviour
{
    // private referencia que solo se usará esta información internamente en el script; public is que utilizará elementos externos
    private Rigidbody2D rb;             // 'rigidbody2D'
    public Transform rayOrigin;         // raycasr


    public float speed;                 // velocidad de movimiento
    public float jump;                  // potencia de salto
    public bool isGrounded;             // tocar el suelo 
    public bool isShooting;             // si está disparando

    private float xMovement;            // guarda el Axis X (horizontal)


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();     // RB se asigna a rb
    }


    private void Update()
    {
        PlayerMovement();   // Funciones (a definir en voids)
        IsGrounded();
        IsShooting();

        if (Input.GetButtonDown("Jump") && isGrounded == true)    // If pulsa 'Jump' y la variable 'isGrounded' es true
        {
            Jump();                                               
        }
    }

    private void PlayerMovement()       
    {
        xMovement = Input.GetAxisRaw("Horizontal");                     // Eje X (Horizontal) se controla con el Horizontal Input
        rb.velocity = new Vector2(xMovement * speed, rb.velocity.y);    // Al valor 'velocity' del rigidbody se le asigna el valor  X -> xMovement * speed y se le deja en Y el valor que tenga
    }
    void Jump()     
    {
        if (isGrounded == true)     
        {
            rb.velocity = new Vector2(0, jump); //Salto
        }
    }
    void IsGrounded()
    {
        RaycastHit2D ray = Physics2D.Raycast(rayOrigin.position, Vector2.down, 10f); // Lanza un raycast 2D desde la posición 'rayOrigin', en dirección hacia abajo y con un alcance de 10 unidades

        if (ray.distance < 0.01f)   // Si el rayo choca con un objeto a una distancia menor de 0.01
        {
            isGrounded = true;      
        }
        else                        
        {
            isGrounded = false;     
        }
    }
    void IsShooting()
    {
        if (Input.GetButton("Fire1") == true)
        {
            isShooting = true;
        }
        else
        {
            isShooting = false;
        }
    }
}

