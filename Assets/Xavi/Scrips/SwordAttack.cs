using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    Rigidbody2D myRigidbody;
    BoxCollider2D myCollider;
   public ParticleSystem blood;
    [SerializeField] int pointsToAdd = 100;

    // Start is called before the first frame update
    void Start()
    {
       myRigidbody = GetComponent<Rigidbody2D>();
       myCollider = GetComponent<BoxCollider2D>();
       blood = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //private void OnTriggerEnter2D(Collider2D other)
    //{
      //  if ( other.tag == "Enemy" )
        //{
          //  Debug.Log(blood);
            //blood.Play();
            //Destroy(other.gameObject);
          //  FindObjectOfType<GameSessionXavi>().AddToScore(pointsToAdd);
        //}
    //}
}
