using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet2_qpalau : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;

    void Start()

    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        Destroy(gameObject, 4f);
    }

}