using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchHazardOscar : MonoBehaviour
{
    public int Damage;
    public Vector3 Repel;

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
            if(collision.GetComponent<Rigidbody2D>() != null)
            {
                Vector3 Dir = new Vector3(1, 1, 1);
                if (collision.transform.localScale.x < 0) { Dir.x = -1; }
                collision.GetComponent<Rigidbody2D>().velocity = Vector3.Scale(Repel, Dir);
            }
        }
    }
}
