using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatformOscar : MonoBehaviour
{
    public float Speed, Timer, GoalTime;
    public Vector3 Dir;
    public bool Going1, Moving;
    public Rigidbody2D RB2D;

    // Start is called before the first frame update
    void Start()
    {
        Timer = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Counting time
        Timer += Time.deltaTime;

        //Moving
        if(Moving == true)
        {
            if(Going1 == true)
            {
                RB2D.MovePosition(transform.position + Dir * Speed * Time.deltaTime);
            }
            else
            {
                RB2D.MovePosition(transform.position - Dir * Speed * Time.deltaTime);
            }

            if(Timer >= GoalTime) { Moving = false; Timer = 0; }
        }
        //Once in position, waiting to move again
        else
        {
            if (Timer >= GoalTime) { Moving = true; Going1 = !Going1; Timer = 0; }
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    collision.transform.SetParent(transform);
    //}

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    collision.transform.SetParent(null);
    //}
}
