using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInput : MonoBehaviour
{
    private Rigidbody2D rb;             // Aquí se asignará el componente 'rigidbody2D'
    public Transform rayOrigin;         // Aquí se asignará el punto desde el que se lanzará el raycast


    public float speed;                 // Aquí se asignará la velocidad de movimiento
    public float jump;                  // Aquí se asignará la potencia del salto
    public bool isGrounded;             // Aquí se comnprobará si el personaje está tocando el suelo

    private float xMovement;            // Aquí se guardará el valor del Axis X que moverá al personaje
    private AnimationManager am;        // Aquí se referencia el script 'AnimationManager'


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();// Se asigna el componente 'Rigidbody2D' a la variable 'rb'
    }


    private void Update()
    {
        PlayerMovement();   // Se llama a la función 'PlayerMovement'
        IsGrounded();       // Se llama a la función 'IsGrounded'

        if (Input.GetButtonDown("Jump") && isGrounded == true)    // Si se pulsa el botón 'Jump' y la variable 'isGrounded' es true
        {
            Jump();                                               // Se llama a la función 'Jump'
        }
        if (Input.GetButtonDown("Fire1"))                         // Si se pulsa el botón 'Fire1'
        {
            am = FindObjectOfType<AnimationManager>();            // Se busca el objeto que tenga el script 'AnimationManager' y se guarda en la variable 'am'
            am.AttackAnimation();                                 // Se llama a la función 'AttackAnimation()' del script 'AnimationManager' 
        }
    }

    private void PlayerMovement()       // Función PlayerMovement()
    {
        xMovement = Input.GetAxisRaw("Horizontal");                     // Se asigna el valor del eje 'Horizontal' a la variable xMovement
        rb.velocity = new Vector2(xMovement * speed, rb.velocity.y);    // Al valor 'velocity' del rigidbody 2d 'rb' se le asigna el valor en X -> xMovement * speed y se le deja en Y el valor que tenga
    }
    void Jump()     // Función Jump()
    {
        if (isGrounded == true)     // Si isGrounded es true
        {
            rb.velocity = new Vector2(0, jump); //Salto
        }
    }
    void IsGrounded()// Función IsGrounded()
    {
        RaycastHit2D ray = Physics2D.Raycast(rayOrigin.position, Vector2.down, 10f); // Lanza un raycast 2D desde la posición 'rayOrigin', en dirección hacia abajo y con un alcance de 10 unidades

        if (ray.distance < 0.01f)   // Si el rayo choca con un objeto que está a una distancia menor de 0.01
        {
            isGrounded = true;      // Activa el bool 'isGrounded' 
        }
        else                        // Si el rayo no choca con un objeto que está a una distancia menor de 0.01
        {
            isGrounded = false;     // Desactiva el bool 'isGrounded'
        }
    }

  
}
