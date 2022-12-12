using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletSpawnGerard : MonoBehaviour
{

    public GameObject BulletEnemy;
    public Transform waypointRight;
    public Transform waypointLeft;
    public Animator anim;
    public SpriteRenderer sr;

    public float bulletRate = 2f;       // no se puede disparar hasta que pasen 5 secs de base.
    public float nextBullet = 0f;
    public bool isFlipped;

    void Start()
    {
        anim = GetComponent<Animator>();    // cogemos el componente para poder saber en que eje está mirando.
    }

    void Update()
    {
        if (Time.time > nextBullet)
        {
            nextBullet = Time.time + bulletRate;                      // No deja disparar de nuevo hasta llegar a 0
            Bullet();
        }


        void Bullet()
        {
            if (sr.flipX == true)
            {

                Instantiate(BulletEnemy, waypointLeft.position, waypointLeft.rotation);
            }
            else
            {
                Instantiate(BulletEnemy, waypointRight.position, waypointRight.rotation);
            }
        }
    }
}
