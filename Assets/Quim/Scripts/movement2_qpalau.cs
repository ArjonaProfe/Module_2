using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement2_qpalau : MonoBehaviour
{
   
    float xInicial, yInicial;  
    private Rigidbody2D rb;
    private float Horizontal;
    private float Vertical;
    public float speed;
    public float jump = 2f;
    private Animator anim;

    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        xInicial = transform.position.x;  
    }


    private void Update()
    {


        Horizontal = Input.GetAxisRaw("Horizontal");     

        rb.velocity = new Vector2(Horizontal * speed, rb.velocity.y);        
        if (Input.GetKeyDown(KeyCode.Space))               
        {
            rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
            Debug.Log("Jump");
        }

        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetBool("Attack", true);      
            Debug.Log("Ataque");
        }
        else
        {
            anim.SetBool("Attack", false);     
        }

        if (Horizontal > 0)                      
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
        if (Horizontal < 0)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
        


    }

    
    public Vector2 GetPosition()
    {
        return transform.position;
    }

    public void SetPosition(Vector2 pos)
    {
        transform.position = pos;
    }

    public void Recolocar()
    {
        transform.position = new Vector3(xInicial, yInicial, 0);
    }



}
