using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinOscar : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            LevelManagerOscar.Shards += 1;
            Destroy(gameObject);
        }
    }
}
