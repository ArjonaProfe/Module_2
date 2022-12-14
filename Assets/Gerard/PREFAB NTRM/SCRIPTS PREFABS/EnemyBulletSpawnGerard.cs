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



    void Start()
    {
        anim = GetComponent<Animator>();    // cogemos el componente para poder saber en que eje está mirando.
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

    void Update()
    {

            Bullet();

    }
}
