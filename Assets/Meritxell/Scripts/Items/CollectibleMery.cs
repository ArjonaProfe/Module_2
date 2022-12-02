using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleMery : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            Destroy(gameObject);
        }
    }
}
