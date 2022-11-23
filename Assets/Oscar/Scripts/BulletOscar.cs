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
        transform.position += transform.right * Speed * Time.deltaTime;
        Destroy(gameObject, 8);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<LifeNStatusOscar>() != null)
        {
            collision.GetComponent<LifeNStatusOscar>().TakeDamage(Power, Potent);
        }
        Destroy(gameObject);
    }
}
