using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MoveBackgroundMery : MonoBehaviour
{

    public float speed;

    private Vector2 change;

    public Rigidbody2D rb;
   

    void Start()
    {     
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        change = Vector2.zero;
        change.x = transform.position.x;

        rb.transform.position = new Vector2(change.x - speed * Time.time, 0);
    }

    public void ResetPosition()
    {
            rb.transform.position = new Vector2(600, 0); 
    }
}
