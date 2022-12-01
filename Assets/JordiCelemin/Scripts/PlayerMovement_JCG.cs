using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerMovement_JCG : MonoBehaviour
{

    private Rigidbody2D rb;
    private float Horizontal;
    public float speed;
    public float jump = 2f;
    private Animator anim;
    private bool mirandoDerecha = true;
    private bool mirandoIzquierda = false;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    private void Update()
    {
       

     Horizontal = Input.GetAxisRaw("Horizontal");                    
     rb.velocity = new Vector2(Horizontal * speed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
        }

        if (Input.GetButtonDown("Fire1"))                         
        {
            anim.SetBool("Attack", true);       //Si pulso ataca con la animacion.                                         
        }
        else
        {
            anim.SetBool("Attack", false);     //Si no, no ataco.
        }
        
        if(speed > 0 && !mirandoDerecha)
        {
            //Girar
        }
        else if(speed < 0 && !mirandoIzquierda)
        {
            //Girar
        }
       

    }

    private void Girar()
    {
        mirandoDerecha = !mirandoDerecha;
        spriteRenderer.flipX = !spriteRenderer.flipX;

    }
    public Vector2 GetPosition()
    {
        return transform.position;
    }
    
    public void SetPosition(Vector2 pos)
    {
        transform.position = pos;
    }

    



}
