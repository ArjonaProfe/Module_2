using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala_JCG : MonoBehaviour
{
   
    public int damage;
    public VidaPlayer_JCG playerHealth;
    public GameObject Bala;

    void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.tag == "Player")
       {
           playerHealth.TakeDamage(damage);
           
       }
       Destroy(Bala, 1f);

    }


}
