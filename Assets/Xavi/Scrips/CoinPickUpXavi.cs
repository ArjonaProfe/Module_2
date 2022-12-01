using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUpXavi : MonoBehaviour
{
    [SerializeField] AudioClip pickUPClip;
    [SerializeField] int pointsForCoinPickup = 100;

    bool wasCollected = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !wasCollected)
        {
            wasCollected = true;
            FindObjectOfType<GameSessionXavi>().AddToScore(pointsForCoinPickup);
            Destroy(gameObject);
        }
    }
}
