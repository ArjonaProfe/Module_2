using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangSpawnGerard : MonoBehaviour
{

    public GameObject BoomerangShoot;
    public Transform waypointRight;
    public Transform waypointLeft;
    public Animator anim;
    public SpriteRenderer sr;

    public float boomerangRate = 5f;       // no se puede disparar hasta que pasen 5 secs de base.
    public float nextBoomerang = 0f;
    public bool isFlipped;

    void Start()
    {
        anim = GetComponent<Animator>();    // cogemos el componente para poder saber en que eje está mirando.
    }

    void Update()
    {
        if (Input.GetButton("Fire2") && Time.time > nextBoomerang)     
        {
            nextBoomerang = Time.time + boomerangRate;                      // No deja disparar de nuevo hasta llegar a 0
            Boomerang();
        }


        void Boomerang()
        {
            if (sr.flipX == true)
            {

                Instantiate(BoomerangShoot, waypointLeft.position, waypointLeft.rotation);
            }
            else
            {
                Instantiate(BoomerangShoot, waypointRight.position, waypointRight.rotation);
            }
        }
    }
}
