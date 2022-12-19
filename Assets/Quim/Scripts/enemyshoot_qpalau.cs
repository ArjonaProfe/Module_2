using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyshoot_qpalau : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bullet_enemy_qpalau;
    float timebetween;
    public float starttimebetween;
    
    void Start()
    {
        timebetween = starttimebetween;
    }

    // Update is called once per frame
    void Update()
    {
        if (timebetween <= 0) 
        {
            Instantiate(bullet_enemy_qpalau, firepoint.position, firepoint.rotation);
            timebetween = starttimebetween;

        }
        else 
        {
            timebetween -= Time.deltaTime;   

        }
        
    }
}
