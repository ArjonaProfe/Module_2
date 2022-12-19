using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasLoopMery : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        rb.transform.Translate(Vector2.left * Time.deltaTime * speed);

        if(transform.position.x < -800)
        {
            rb.transform.position = new Vector2(115, transform.position.y);
        }
    }
}


 