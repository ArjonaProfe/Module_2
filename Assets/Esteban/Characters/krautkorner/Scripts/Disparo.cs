using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private float daño;
    private Animator animatorHit;
    private GameObject hitgameObject;
    void Start()
    {
        hitgameObject = gameObject.transform.Find("animHit").gameObject;
        animatorHit = hitgameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       transform.Translate(Vector2.right* velocidad *Time.deltaTime); 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy1"))
        {

            collision.gameObject.GetComponent<Enemy1Damage_Es>().Damage(10);
            animatorHit.SetBool("Hit", true);
            velocidad= 0;
            Destroy(gameObject,0.1f);
        }
    }
}
