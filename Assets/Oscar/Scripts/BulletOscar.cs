using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletOscar : MonoBehaviour
{
    public int Power;
    public float Speed, Lifetime;
    public bool Potent;
    public LifeNStatusOscar.Faction MyFaction;

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
        Destroy(gameObject, Lifetime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<LifeNStatusOscar>() != null && collision.GetComponent<LifeNStatusOscar>().MyFaction != MyFaction)
        {
            collision.GetComponent<LifeNStatusOscar>().TakeDamage(Power, Potent);
            Destroy(gameObject);
        }

        if (collision.GetComponent<BulletOscar>() != null && collision.GetComponent<BulletOscar>().MyFaction != MyFaction)
        {
            Destroy(gameObject);
        }

        if (collision.GetComponent<HitGizmoOscar>() != null)
        {
            collision.GetComponent<HitGizmoOscar>().Reaction();
            Destroy(gameObject);
        }

        if(collision.tag == "Ground") { Destroy(gameObject); }
    }
}
