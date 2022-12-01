using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo_JCG : MonoBehaviour
{
    public string Enemigo_JCGName;
    public float healthPoints;
    private Rigidbody2D rb;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {

       


    }
}
