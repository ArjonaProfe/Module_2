using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;

public class NewAnimationEnemyMery : MonoBehaviour
{
    // private referencia que solo se usará esta información internamente en el script; public is que utilizará elementos externos
    private Animator anim;            //  Animator se abreviará como anim y se asigna al Animator del objeto al que se asocie
    private SpriteRenderer sr;        //  "
    private Rigidbody2D rb;
    float direction = 1;
    public float speed;

    private void Start()
    {
        anim = GetComponent<Animator>();    // Las variables deben asignarse a los componentes
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
       
        direction = direction - speed * Time.deltaTime;
        transform.position = new Vector2(direction, transform.position.y);
        Debug.Log(direction); 
    }
}
