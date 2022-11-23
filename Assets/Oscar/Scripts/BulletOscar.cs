using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletOscar : MonoBehaviour
{
    public int Power;
    public float Speed;
    public bool Potent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Moving in the direction it is facing (can be redirected by rotation)
        transform.position += transform.right * Speed * Time.deltaTime;

        //Destroyed if it exist for too long
        Destroy(gameObject, 8);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<LifeNStatusOscar>() != null)
        {
            collision.GetComponent<LifeNStatusOscar>().TakeDamage(Power, Potent);
        }
        print(collision.name);
        Destroy(gameObject);
    }
}
