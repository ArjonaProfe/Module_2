using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControlOscar : MonoBehaviour
{
    //Other scripts
    public LifeNStatusOscar LifeMan;
    public Animator Anim;
    public BoxCollider2D NormalColl;

    //Detections
    public GameObject Target;
    public float TarDist, TarDistX, TarDistY, RangedDist, MeleeDist;
    public Transform GroundPoint;
    public bool Grounded;
    public LayerMask IsGround;
    public bool JustPounded;

    //General bariables for Actions
    public Transform CanonPoint, UpperPoint;
    public float ActTimer, ActCool;
    public float AtkRadius;
    public LayerMask IsEnemy, IsAlly;

    //MeleeActions
    public int MeleeDmg, ShotAngle;
    public GameObject PelletProp;

    //Ranged actions
    public GameObject BulletProp;
    public int FirePow;
    public float SuppRadius;

    //Turning to braggable item
    public GrabItemOscar MyGrab;
    public BoxCollider2D GrabColl;
    

    // Start is called before the first frame update
    void Start()
    {
        Target = FindObjectOfType<PlayerControlOscar>().gameObject;
        if(MyGrab != null) { MyGrab.enabled = false; }
        if(GrabColl != null) { GrabColl.enabled = false; }
    }

    // Update is called once per frame
    void Update()
    {
        if(Target != null)
        {
            TarDist = Vector2.Distance(transform.position, Target.transform.position);
            TarDistX = Mathf.Abs(Target.transform.position.x - transform.position.x);
            TarDistY = Mathf.Abs(Target.transform.position.y - transform.position.y);

            //Deciding between two actions, depending on the distance to the player
            if (TarDist < RangedDist && TarDist > MeleeDist)
            {
                if (ActTimer >= ActCool)
                {
                    Anim.SetTrigger("RangedAct");
                    ActTimer = 0;
                }
            }
            else if (TarDist <= MeleeDist && TarDistX > TarDistY)
            {
                if (ActTimer >= ActCool)
                {
                    Anim.SetTrigger("MeleeAct");
                    ActTimer = 0;
                }
            }
        }

        //Memorize if it's been pounded, and react if going to be pounded again
        if (TarDistY > 2 && Mathf.Abs(TarDistX) < 1 && JustPounded == true)
        {
            Anim.SetTrigger("UpwardsAct");
            ActTimer = 0;
            JustPounded = false;
        }

        if (TarDistY > 1 && Mathf.Abs(TarDistX) < 1 && LifeMan.JustHurted == true)
        {
            JustPounded = true;
            LifeMan.JustHurted = false;
        }
        if(Mathf.Abs(TarDistX) > 1 && JustPounded == true) { JustPounded = false; }
        
        LifeMan.JustHurted = false;

        //Ground dectection
        Grounded = Physics2D.OverlapCircle(GroundPoint.position, 0.05f, IsGround);
        Anim.SetBool("Grounded", Grounded);

        //Die if fall
        if(transform.position.y < -20) { LifeMan.Death(); }
    }

    //Melee actions
    public void MeleeAttack()
    {
        Collider2D[] EnemiesToDamage = Physics2D.OverlapCircleAll(CanonPoint.transform.position, AtkRadius, IsEnemy);
        for (int i = 0; i < EnemiesToDamage.Length; i++)
        {
            if (EnemiesToDamage[i].GetComponent<LifeNStatusOscar>().MyFaction != LifeMan.MyFaction)
            {
                EnemiesToDamage[i].GetComponent<LifeNStatusOscar>().TakeDamage(MeleeDmg, LifeNStatusOscar.DmgType.Weak);
            }
        }
        ActTimer = 0;
    }

    public void ShotgunBlast(int Ammo)
    {
        for (int i = 0; i < Ammo; i++)
        {
            int angle = (ShotAngle * (Ammo - 1) / 2) - ShotAngle * i;
            int turner = 0; if(transform.localScale.x < 0) { turner = 180; }
            GameObject NewPellet = Instantiate(PelletProp, CanonPoint.position, Quaternion.Euler(0, 0, angle + turner));
            NewPellet.GetComponent<BulletOscar>().MyFaction = LifeMan.MyFaction;
            NewPellet.GetComponent<BulletOscar>().Power = MeleeDmg;
        }
    }


    //Ranged actions
    public void ShotProjectile()
    {
        Vector3 Dir = new Vector3(0, 0, 0);
        if (transform.localScale.x < 0) { Dir.y = 180; }
        GameObject NewFire = Instantiate(BulletProp, CanonPoint.position, Quaternion.Euler(Dir));
        NewFire.GetComponent<BulletOscar>().MyFaction = LifeMan.MyFaction;
        NewFire.GetComponent<BulletOscar>().Power = FirePow;
        ActTimer = 0;
    }

    public void AreaHeal()
    {
        Collider2D[] AlliesToHeal = Physics2D.OverlapCircleAll(transform.position, SuppRadius, IsAlly);
        for (int i = 0; i < AlliesToHeal.Length; i++)
        {
            if (AlliesToHeal[i].GetComponent<LifeNStatusOscar>().MyFaction == LifeMan.MyFaction)
            {
                AlliesToHeal[i].GetComponent<LifeNStatusOscar>().Heal(FirePow);
            }
        }
        
    }

    //Upwards actions
    public void UpMeleeAttack()
    {
        Collider2D[] EnemiesToDamage = Physics2D.OverlapCircleAll(UpperPoint.transform.position, AtkRadius, IsEnemy);
        for (int i = 0; i < EnemiesToDamage.Length; i++)
        {
            if (EnemiesToDamage[i].GetComponent<LifeNStatusOscar>().MyFaction != LifeMan.MyFaction)
            {
                EnemiesToDamage[i].GetComponent<LifeNStatusOscar>().TakeDamage(MeleeDmg, LifeNStatusOscar.DmgType.Weak);
            }
        }
        ActTimer = 0;
    }

    //Turn to grabbable item
    public void GoGrabbable()
    {
        LifeMan.enabled = false;
        MyGrab.enabled = true;
        Anim.SetTrigger("GoGrabbable");
        int Lay = LayerMask.NameToLayer("Grabbable");
        gameObject.layer = Lay;
        NormalColl.enabled = false;
        GrabColl.enabled = true;
        this.enabled = false;
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
        Gizmos.DrawWireSphere(UpperPoint.position, AtkRadius);
        //Detection
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, RangedDist);
        Gizmos.DrawWireSphere(transform.position, MeleeDist);
    }
}
