using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovementXavi : MonoBehaviour
{
    Rigidbody2D myRigidbody;
    [SerializeField] float speedX = 2f;
    [SerializeField] float timerToFlipPlatform = 3f;


    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Movement();

    }

    void Movement()
    {

        if ( timerToFlipPlatform > 0 )
        {
            myRigidbody.velocity = new Vector2(speedX, 0f);
            timerToFlipPlatform -= Time.deltaTime;


        }
        else
        {
            timerToFlipPlatform = 5f;
            speedX = -speedX;
        }

    }

  
}
