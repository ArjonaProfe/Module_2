using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyXavi : MonoBehaviour
{

    Rigidbody2D myRigidbody;
    Animator myAnimator;

    [SerializeField] float speedX = 5f;
 
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        
    }


    void Update()
    {
        Movement();
        Flip();
    }


    void Movement()
    {
        myRigidbody.velocity = new Vector2(speedX , 0f);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        speedX = -speedX;
        Flip();
    }

    void Flip()
    {
        transform.localScale = new Vector2(Mathf.Sign((myRigidbody.velocity.x)), 1f);

    }
}
