using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manolo_JCG : MonoBehaviour
{
    private Rigidbody2D rb;
    private float Horizontal;
    public float speed;
    public float jump = 2f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
       
     Horizontal = Input.GetAxisRaw("Horizontal");                    
     rb.velocity = new Vector2(Horizontal * speed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
        }
    }
    

   
}
