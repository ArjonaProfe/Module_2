using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_qpalau : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;

    void Start()

    { 
        rb.velocity = transform.right * speed;
        Destroy(gameObject, 4f);
    }

        void OnTriggerEnter2D (Collider2D hitInfo)

    {
        Debug.Log(hitInfo.name);
        Destroy(gameObject);
        
    }

}


