using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewAnimationEnemyMery : MonoBehaviour
{
    // private referencia que solo se usará esta información internamente en el script; public is que utilizará elementos externos
    private Animator anim;            //  Animator se abreviará como anim y se asigna al Animator del objeto al que se asocie
    private SpriteRenderer sr;        //  "
    private Rigidbody2D rb;

    public float speed;

    private void Start()
    {
        anim = GetComponent<Animator>();    // Las variables deben asignarse a los componentes
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        
            transform.position = new Vector3(speed + 1 * Time.deltaTime, transform.position.y, transform.position.z);

    }
}
