using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletGerard : MonoBehaviour
{
    public float speed;                           // asignamos un numero a speed para poder controlar la velocidad.
    public Rigidbody2D rb;                              // se asigna el componente "X" a rb.



    void Update()
    {

        rb.velocity = transform.right * speed;

        Destroy(gameObject, 1.2f);
    }
}
