using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabItemOscar : MonoBehaviour
{
    public enum GrabType { Barrel, Bomb, Key, VillainKey, PrincessKey}
    public GrabType MyType;
    public Rigidbody2D RB2D;
    public LayerMask IsEnemy, IsGizmo;
    public GameObject ParSys;
    public Animator Anim;
    public bool Carried;
    public Vector3 StartPos;

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
        StartPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(MyType == GrabType.Bomb)
        {
            if(Carried == true) { Anim.SetBool("Carried", true); }
        }

        if (MyType == GrabType.Key || MyType == GrabType.VillainKey || MyType == GrabType.PrincessKey)
        {
            if(transform.position.y < -20) { transform.position = StartPos; RB2D.velocity = new Vector2(0, 0); }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Barrel breaks when thrown, causing normal damage
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

        //The key destrois the lock and itself when it enters in contact with one of it's own category
        if(MyType == GrabType.Key || MyType == GrabType.VillainKey || MyType == GrabType.PrincessKey)
        {
            if(collision.gameObject.GetComponent<LockOscar>() != null && collision.gameObject.GetComponent<LockOscar>().MyType == MyType)
            {
                collision.gameObject.GetComponent<LockOscar>().OpenSalami();
                Destroy(gameObject);
            }
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
