using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInput : MonoBehaviour
{
    private Rigidbody2D rb;             // Aqu� se asignar� el componente 'rigidbody2D'
    public Transform rayOrigin;         // Aqu� se asignar� el punto desde el que se lanzar� el raycast


    public float speed;                 // Aqu� se asignar� la velocidad de movimiento
    public float jump;                  // Aqu� se asignar� la potencia del salto
    public bool isGrounded;             // Aqu� se comnprobar� si el personaje est� tocando el suelo

    private float xMovement;            // Aqu� se guardar� el valor del Axis X que mover� al personaje
    private AnimationManager am;        // Aqu� se referencia el script 'AnimationManager'


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();// Se asigna el componente 'Rigidbody2D' a la variable 'rb'
    }


    private void Update()
    {
        PlayerMovement();   // Se llama a la funci�n 'PlayerMovement'
        IsGrounded();       // Se llama a la funci�n 'IsGrounded'

        if (Input.GetButtonDown("Jump") && isGrounded == true)    // Si se pulsa el bot�n 'Jump' y la variable 'isGrounded' es true
        {
            Jump();                                               // Se llama a la funci�n 'Jump'
        }
        if (Input.GetButtonDown("Fire1"))                         // Si se pulsa el bot�n 'Fire1'
        {
            am = FindObjectOfType<AnimationManager>();            // Se busca el objeto que tenga el script 'AnimationManager' y se guarda en la variable 'am'
            am.AttackAnimation();                                 // Se llama a la funci�n 'AttackAnimation()' del script 'AnimationManager' 
        }
    }

    private void PlayerMovement()       // Funci�n PlayerMovement()
    {
        xMovement = Input.GetAxisRaw("Horizontal");                     // Se asigna el valor del eje 'Horizontal' a la variable xMovement
        rb.velocity = new Vector2(xMovement * speed, rb.velocity.y);    // Al valor 'velocity' del rigidbody 2d 'rb' se le asigna el valor en X -> xMovement * speed y se le deja en Y el valor que tenga
    }
    void Jump()     // Funci�n Jump()
    {
        if (isGrounded == true)     // Si isGrounded es true
        {
            rb.velocity = new Vector2(0, jump); //Salto
        }
    }
    void IsGrounded()// Funci�n IsGrounded()
    {
        RaycastHit2D ray = Physics2D.Raycast(rayOrigin.position, Vector2.down, 10f); // Lanza un raycast 2D desde la posici�n 'rayOrigin', en direcci�n hacia abajo y con un alcance de 10 unidades

        if (ray.distance < 0.01f)   // Si el rayo choca con un objeto que est� a una distancia menor de 0.01
        {
            isGrounded = true;      // Activa el bool 'isGrounded' 
        }
        else                        // Si el rayo no choca con un objeto que est� a una distancia menor de 0.01
        {
            isGrounded = false;     // Desactiva el bool 'isGrounded'
        }
    }

  
}
