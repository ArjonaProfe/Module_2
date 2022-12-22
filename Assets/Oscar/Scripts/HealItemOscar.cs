using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealItemOscar : MonoBehaviour
{
    public int Amount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<LifeNStatusOscar>().Heal(Amount);
            Destroy(gameObject);
        }
    }
}
