using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementXavi : MonoBehaviour
{
    private Rigidbody2D rb;
    public Transform rayOriginXavi;
    private SpriteRenderer sr;
    private PlayerInput pi;
    private Animator anim;
    BoxCollider2D myCollider;

    [SerializeField] float speed;
    [SerializeField] float jump;
    private float xMovement;

    public bool isGrounded;
    public bool attack = false;
    public bool isAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        IsGrounded();
        MeleeAttack();
        Die();

        if (Input.GetButtonDown("Jump") && isGrounded == true)    // Si se pulsa el botón 'Jump' y la variable 'isGrounded' es true
        {
            Jump();                                               // Se llama a la función 'Jump'
        }
        anim.SetInteger("xValue", Mathf.RoundToInt(rb.velocity.x));   // Se setea el entero 'SpeedMovement' del animator con el valor 'rb.velocity.x' redondeado a entero
        anim.SetBool("Ground", isGrounded);

        // anim.SetBool("Attack", attack);


    }

    private void Movement()
    {
        if (!isAlive) { return; }

        if (attack == true)
        {
            return;
        }
        xMovement = Input.GetAxisRaw("Horizontal");                     // Se asigna el valor del eje 'Horizontal' a la variable xMovement
        rb.velocity = new Vector2(xMovement * speed, rb.velocity.y);
        if (xMovement < 0)
        {
            sr.flipX = true;
        }
        else if (xMovement > 0)
        {
            sr.flipX = false;
        }
    }

    private void Jump()
    {
        if (!isAlive) { return; }

        if (isGrounded == true)     // Si isGrounded es true
        {
            rb.velocity = new Vector2(0, jump); //Salto
            isGrounded = false;
        }
    }
    void MeleeAttack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            attack = true;
            Debug.Log("attack");

        }
        anim.SetBool("MeleeAttack", attack);

    }
    // public void AttackAnimation()                                             // Función encargada de activar el bool "attack" 
    //{
    //   if (Input.GetButtonDown("Fire1"))                         // Si se pulsa el botón 'Fire1'
    // {
    //      attack = true;                     
    // }        
    //}

    void IsGrounded()// Función IsGrounded()
    {
        RaycastHit2D ray = Physics2D.Raycast(rayOriginXavi.position, Vector2.down, 10f); // Lanza un raycast 2D desde la posición 'rayOrigin', en dirección hacia abajo y con un alcance de 10 unidades

        if (ray.distance < 0.01f)   // Si el rayo choca con un objeto que está a una distancia menor de 0.01
        {
            isGrounded = true;      // Activa el bool 'isGrounded' 
        }
        else                        // Si el rayo no choca con un objeto que está a una distancia menor de 0.01
        {
            isGrounded = false;     // Desactiva el bool 'isGrounded'
        }
    }

    void Die()
    {
        if (myCollider.IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazards")))
        {
            isAlive = false;
            anim.SetTrigger("Dying");
            rb.velocity = new Vector2(0, 20f);
            //FindObjectOfType<GameSession>().ProcessPlayerDeath();
        }
    }
}