using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttactEnemy : MonoBehaviour
{
    public float speed;
    public float time;
    private float resetTime;

    public GameObject misPelotas;


   // private bool blockTimer = false;

    public bool attack;
    // Start is called before the first frame update
    void Start()
    {
        resetTime = time;
    }

    // Update is called once per frame
    void Update()
    {
        
            time = time - 1 * Time.deltaTime;
            EnemyMovement();
        
    }

    void EnemyMovement()
    {
        attack = false;
        if (attack == false)
        {
            transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
            if (time < 0)
            {
                speed = speed * -1;
                attack = true;
                EnemyAttack();
            }
        }
      
    }
    void EnemyAttack()
    {
        transform.position = transform.position;

        Debug.Log(attack);
        if (time < -1)
        {
            time = resetTime;
            attack = false;

        }

    }
}
