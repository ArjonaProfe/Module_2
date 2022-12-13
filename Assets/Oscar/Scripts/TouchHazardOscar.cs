using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchHazardOscar : MonoBehaviour
{
    public int Damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<LifeNStatusOscar>() != null)
        {
            collision.GetComponent<LifeNStatusOscar>().TakeDamage(Damage, LifeNStatusOscar.DmgType.Weak);
            if(collision.GetComponent<PlayerControlOscar>() != null)
            {
                collision.GetComponent<PlayerControlOscar>().ReturnToPos();
            }
        }
    }
}
