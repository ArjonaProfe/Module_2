using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControlOscar : MonoBehaviour
{
    //Other scripts
    public LifeNStatusOscar LifeMan;
    public Animator Anim;

    //Detections
    public GameObject Target;
    public float TarDist, RangedDist, MeleeDist;
    public Transform GroundPoint;
    public bool Grounded;
    public LayerMask IsGround;

    //General bariables for Actions
    public Transform CanonPoint;
    public float ActTimer, ActCool;
    public float AtkRadius;
    public LayerMask IsEnemy;

    //MeleeActions
    public int MeleeDmg;

    //Ranged actions
    public GameObject BulletProp;
    public int FirePow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TarDist = Vector2.Distance(transform.position, Target.transform.position);

        if(ActTimer < ActCool) { ActTimer += Time.deltaTime; }

        //Deciding between two actions, depending on the distance to the player
        if(TarDist < RangedDist && TarDist > MeleeDist)
        {
            if((Target.transform.position.x < transform.position.x && transform.localScale.x > 0) || (Target.transform.position.x > transform.position.x && transform.localScale.x < 0))
            {
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            }
            if (ActTimer >= ActCool)
            {
                Anim.SetTrigger("RangedAct");
                ActTimer = 0;
            }
        }
        else if(TarDist <= MeleeDist)
        {
            if ((Target.transform.position.x < transform.position.x && transform.localScale.x > 0) || (Target.transform.position.x > transform.position.x && transform.localScale.x < 0))
            {
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            }
            if (ActTimer >= ActCool)
            {
                Anim.SetTrigger("MeleeAct");
                ActTimer = 0;
            }
        }

        //Ground dectection
        Grounded = Physics2D.OverlapCircle(GroundPoint.position, 0.05f, IsGround);
        Anim.SetBool("Grounded", Grounded);
    }

    //Melee actions
    public void MeleeAttack()
    {
        Collider2D[] EnemiesToDamage = Physics2D.OverlapCircleAll(CanonPoint.transform.position, AtkRadius, IsEnemy);
        for (int i = 0; i < EnemiesToDamage.Length; i++)
        {
            if (EnemiesToDamage[i].GetComponent<LifeNStatusOscar>().MyFaction != LifeMan.MyFaction)
            {
                EnemiesToDamage[i].GetComponent<LifeNStatusOscar>().TakeDamage(MeleeDmg, false);
            }
        }
        ActTimer = 0;
    }

    //Ranged Actions
    public void ShotProjectile()
    {
        Vector3 Dir = new Vector3(0, 0, 0);
        if (transform.localScale.x < 0) { Dir.y = 180; }
        GameObject NewFire = Instantiate(BulletProp, CanonPoint.position, Quaternion.Euler(Dir));
        NewFire.GetComponent<BulletOscar>().Power = FirePow;
        ActTimer = 0;
    }

    //Grafics for visualization
    private void OnDrawGizmosSelected()
    {
        //ground detector
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(GroundPoint.transform.position, 0.08f);
        //punch
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(CanonPoint.position, AtkRadius);
        //Detection
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, RangedDist);
        Gizmos.DrawWireSphere(transform.position, MeleeDist);
    }
}
