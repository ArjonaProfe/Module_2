using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUpXavi : MonoBehaviour
{
    [SerializeField] AudioClip pickUPClip;
    [SerializeField] int pointsForCoinPickup = 100;
    Transform pickUp;

    bool wasCollected = false;
    private void Start()
    {
        pickUp = GetComponent<Transform>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !wasCollected)
        {
            wasCollected = true;
            AudioSource.PlayClipAtPoint(pickUPClip,pickUp.position);
            FindObjectOfType<GameSessionXavi>().AddToScore(pointsForCoinPickup);
            Destroy(gameObject);
        }
    }
}
