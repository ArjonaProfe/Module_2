using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangMovementGerard : MonoBehaviour
{
    public float speed;
    public float timertocome = 3f;
    private float resetCooldown = 0f;

    void Start()
    {
        resetCooldown = timertocome;
    }

   
    void Update()
    {
        if(timertocome > 2.9f);
        { 
             timertocome = timertocome - 1 * Time.deltaTime;
             this.transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }

        if (timertocome < 0);
        {
            this.transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);

            timertocome = resetCooldown;

            Object.Destroy(this, 7f);
        }


    }

}
