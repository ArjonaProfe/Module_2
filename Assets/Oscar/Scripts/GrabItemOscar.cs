using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabItemOscar : MonoBehaviour
{
    public enum GrabType { Barrel, Bomb, Key}
    public GrabType MyType;
    public Rigidbody2D RB2D;
    public LayerMask IsEnemy, IsGizmo;
    public GameObject ParSys;
    public Animator Anim;
    public bool Carried;

    //Barrel
    public float BarrelRadius;
    public int BarrelDmg;
    public bool Thrown;

    //Bomb
    public float BombRadius;
    public int BombDmg;
    

    // Start is called before the first frame update
    void Start()
    {
        RB2D = GetComponent<Rigidbody2D>();
        Carried = false;
        Thrown = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(MyType == GrabType.Bomb)
        {
            if(Carried == true) { Anim.SetBool("Carried", true); }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(MyType == GrabType.Barrel && Thrown == true)
        {
            Collider2D[] EnemiesToDamage = Physics2D.OverlapCircleAll(transform.position, BarrelRadius, IsEnemy);
            Collider2D[] Gizmos = Physics2D.OverlapCircleAll(transform.position, BarrelRadius, IsGizmo);
            for (int i = 0; i < EnemiesToDamage.Length; i++)
            {
                EnemiesToDamage[i].GetComponent<LifeNStatusOscar>().TakeDamage(BarrelDmg, false);
            }
            for (int i = 0; i < Gizmos.Length; i++)
            {
                Gizmos[i].GetComponent<HitGizmoOscar>().Reaction();
            }
            Instantiate(ParSys, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if(MyType == GrabType.Key && collision.gameObject.GetComponent<LockOscar>() != null)
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    public void Explode()
    {
        Collider2D[] EnemiesToDamage = Physics2D.OverlapCircleAll(transform.position, BombRadius, IsEnemy);
        Collider2D[] Gizmos = Physics2D.OverlapCircleAll(transform.position, BombRadius, IsGizmo);
        for (int i = 0; i < EnemiesToDamage.Length; i++)
        {
            EnemiesToDamage[i].GetComponent<LifeNStatusOscar>().TakeDamage(BombDmg, true);
        }
        for (int i = 0; i < Gizmos.Length; i++)
        {
            Gizmos[i].GetComponent<HitGizmoOscar>().Reaction();
        }
        Instantiate(ParSys, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        //ground detector
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, BarrelRadius);
        //punch
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, BombRadius);
    }
}
