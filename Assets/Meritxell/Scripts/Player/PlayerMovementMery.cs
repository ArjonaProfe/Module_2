using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovementMery : MonoBehaviour     // Script asignado a los controles del jugador
{
    // private referencia que solo se usará esta información internamente en el script; public is que utilizará elementos externos
    private static Rigidbody2D rb;             // 'rigidbody2D'
    public Transform rayOrigin;         // raycast


    public float speed;                 // velocidad de movimiento
    public float jump;                  // potencia de salto
    public bool isGrounded;             // tocar el suelo 
    public bool isShooting;             // si está disparando
    public bool isDucking;

    private float xMovement;            // guarda el Axis X (horizontal)
    public static bool switchedCam;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();     // RB se asigna a rb
    }


    private void Update()
    {
        PlayerMovement();   // Funciones (a definir en voids)
        IsGrounded();
        IsShooting();
        IsDucking();

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
            rb.velocity = new Vector2(0, jump);       //Salto
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
        if (Input.GetButton("Fire1") == true)      // Si el input está (continuamente) presionado, entonces isShooting es true
        {
            isShooting = true;
        }
        else                                      // Si no, es false
        {
            isShooting = false;
        }
    }

    void IsDucking()
    {
        if(isDucking == false)                    // Mientras el bool isDucking es falso
        {
            GetComponent<BoxCollider2D>().size = new Vector2(0.25f, 0.29f);            // El collider tiene este tamaño
            GetComponent<BoxCollider2D>().offset = new Vector2(0f, 0.15f);
        }


        if (Input.GetAxisRaw("Vertical") < 0)    // Si el input vertical es menor a 0, aka estás pulsando abajo (nota: get axis raw solo reconoce 1, 0 y -1; sin float)
        {
            isDucking = true;                                                        // El bool es verdadero y el collider tiene este otro tamaño
            GetComponent<BoxCollider2D>().size = new Vector2(0.25f, 0.2f);   
            GetComponent<BoxCollider2D>().offset = new Vector2(0f, 0.105f);
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
        }
        else
        {
            isDucking = false;
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }

    public static void MovePlayer()
    {
        if(CameraMery.switchedCam == true)
        {
            rb.transform.position = new Vector2(243, -49);
        }
        else if (CameraMery.switchedCam == false)
        {
            rb.transform.position = new Vector2(244, 2);
        }

    }

}

