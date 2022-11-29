using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlOscar : MonoBehaviour
{
    //Comunication with other scripts
    public LifeNStatusOscar LifeMan;
    public LevelManagerOscar LvMan;
    public Animator Anim;
    public Rigidbody2D RB2D;

    //Stats
    public float JumpSpeed;
    public int MeleeDmg, CharMeleeDmg;
    public float CharTimer, CharGoal;

    //Movement
    public float MoveX, MoveY;

    //Detections
    public Transform GroundPoint, HangPoint1, HangPoint2;
    public bool Grounded, HangAbal, Hangging;
    public LayerMask IsGround, IsTrueGround, IsLader;

    public Transform CanonPoint;
    public float AtkRadius;
    public LayerMask IsEnemy, IsGizmo;

    //Fireball throw
    public GameObject FireProp;
    public int FirePow;

    //Grab and throw
    public LayerMask IsGrabbable;
    public GameObject Carried;
    public Vector2 ThrowVec;

    //Respawn
    public Transform TruPointA, TruPointB;
    public bool TruGroundedA, TruGroundedB;
    public Vector3 PosToReturn;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Moving
        MoveX = Input.GetAxisRaw("Horizontal");
        MoveY = Input.GetAxisRaw("Vertical");
        if (MoveX != 0)
        {
            transform.localScale = new Vector3(4 * MoveX, 4, 1);
            Anim.SetBool("Running", true);
        }
        else if(MoveY != 0 && Hangging == true)
        {
            Anim.SetBool("Running", true);
        }
        else { Anim.SetBool("Running", false); }

        //Ground detection and jump
        Grounded = Physics2D.OverlapCircle(GroundPoint.position, 0.05f, IsGround);
        Anim.SetBool("Grounded", Grounded);
        if ((Input.GetButtonDown("Jump") || MoveY > 0) && Grounded == true)
        {
            RB2D.velocity = new Vector2(RB2D.velocity.x, JumpSpeed);
        }

        //Melee Attack
        if (Input.GetButton("Fire1"))
        {
            Anim.SetBool("MeleeCharge", true);
            if(CharTimer < CharGoal)
            {
                CharTimer += Time.deltaTime;
            }
        }
        else { Anim.SetBool("MeleeCharge", false);}
        Anim.SetFloat("CharTime", CharTimer);

        //Fireball shot
        if (Input.GetButtonDown("Fire2"))
        {
            Anim.SetTrigger("Fireball");
        }

        //Groundpound
        if(Input.GetAxisRaw("Vertical") < 0 && Grounded == false)
        {
            Anim.SetBool("GroundPound", true);
        }
        else { Anim.SetBool("GroundPound", false); }

        //Grab
        if (Input.GetButtonDown("Fire3") && Hangging == false)
        {
            if(Carried == null) { Anim.SetTrigger("Grabbing"); }
            else { Anim.SetTrigger("Throwing"); }
        }

        if(Carried != null)
        {
            Anim.SetBool("Carrying", true);
            Carried.transform.position = CanonPoint.position;

            //Let object fall if damaged
            if (LifeMan.JustHurted == true)
            {
                Carried.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1);
                Carried = null;
                LifeMan.JustHurted = false;
            }
        }
        else { Anim.SetBool("Carrying", false); }
        //Let object fall if damaged
        if (LifeMan.JustHurted == true)
        {
            LifeMan.JustHurted = false;
        }

        //Detect laders
        HangAbal = Physics2D.OverlapArea(HangPoint1.position, HangPoint2.position, IsLader);
        if(HangAbal == false) { Hangging = false; }
        //Climb
        if(Hangging == true && HangAbal == true)
        {
            Anim.SetBool("Climbing", true);

            if (Input.GetButtonDown("Fire3"))
            {
                Hangging = false;
            }
            if (Input.GetButtonDown("Jump"))
            {
                RB2D.velocity = new Vector2(RB2D.velocity.x, JumpSpeed);
                Hangging = false;
            }
        }
        else { Anim.SetBool("Climbing", false); }

        //Respawn if fall
        TruGroundedA = Physics2D.OverlapCircle(TruPointA.position, 0.01f, IsTrueGround);
        TruGroundedB = Physics2D.OverlapCircle(TruPointB.position, 0.01f, IsTrueGround);
        if(TruGroundedA == true && TruGroundedB == true) { PosToReturn = transform.position; }

        if (transform.position.y < -20)
        {
            RB2D.velocity = new Vector3(0, 0, 0);
            transform.position = PosToReturn;
            LifeMan.TakeDamage(10, false);
        }

    }

    //Attacks
    public void MeleeAttack()
    {
        Collider2D[] EnemiesToDamage = Physics2D.OverlapCircleAll(CanonPoint.transform.position, AtkRadius, IsEnemy);
        Collider2D[] Gizmos = Physics2D.OverlapCircleAll(CanonPoint.transform.position, AtkRadius, IsGizmo);
        for (int i = 0; i < EnemiesToDamage.Length; i++)
        {
            if (EnemiesToDamage[i].GetComponent<LifeNStatusOscar>().MyFaction != LifeMan.MyFaction)
            {
                EnemiesToDamage[i].GetComponent<LifeNStatusOscar>().TakeDamage(MeleeDmg, false);
            }
        }
        for (int i = 0; i < Gizmos.Length; i++)
        {
            Gizmos[i].GetComponent<HitGizmoOscar>().Reaction();
        }
        CharTimer = 0;
    }

    public void ChargedMeleeAttack()
    {
        Collider2D[] EnemiesToDamage = Physics2D.OverlapCircleAll(CanonPoint.transform.position, AtkRadius, IsEnemy);
        Collider2D[] Gizmos = Physics2D.OverlapCircleAll(CanonPoint.transform.position, AtkRadius, IsGizmo);
        for (int i = 0; i < EnemiesToDamage.Length; i++)
        {
            if (EnemiesToDamage[i].GetComponent<LifeNStatusOscar>().MyFaction != LifeMan.MyFaction)
            {
                EnemiesToDamage[i].GetComponent<LifeNStatusOscar>().TakeDamage(CharMeleeDmg, true);
            }
        }
        for (int i = 0; i < Gizmos.Length; i++)
        {
            Gizmos[i].GetComponent<HitGizmoOscar>().Reaction();
        }
        CharTimer = 0;
    }

    public void RunMeleeAttack()
    {
        Collider2D[] EnemiesToDamage = Physics2D.OverlapCircleAll(CanonPoint.transform.position, AtkRadius, IsEnemy);
        Collider2D[] Gizmos = Physics2D.OverlapCircleAll(CanonPoint.transform.position, AtkRadius, IsGizmo);
        for (int i = 0; i < EnemiesToDamage.Length; i++)
        {
            if (EnemiesToDamage[i].GetComponent<LifeNStatusOscar>().MyFaction != LifeMan.MyFaction)
            {
                EnemiesToDamage[i].GetComponent<LifeNStatusOscar>().TakeDamage((int)((float)MeleeDmg * 1.5f), false);
            }
        }
        for (int i = 0; i < Gizmos.Length; i++)
        {
            Gizmos[i].GetComponent<HitGizmoOscar>().Reaction();
        }
        CharTimer = 0;
    }

    public void FireballThrow()
    {
        Vector3 Dir = new Vector3(0, 0, 0);
        if(transform.localScale.x < 0) { Dir.y = 180; }
        GameObject NewFire = Instantiate(FireProp, CanonPoint.position, Quaternion.Euler(Dir));
        NewFire.GetComponent<BulletOscar>().MyFaction = LifeMan.MyFaction;
        NewFire.GetComponent<BulletOscar>().Power = FirePow;
    }

    //Grab and Throw
    public void GrabItem()
    {
        Collider2D[] Grabbed = Physics2D.OverlapCircleAll(CanonPoint.transform.position, AtkRadius*2, IsGrabbable);
        if(Grabbed.Length != 0)
        {
            Carried = Grabbed[0].gameObject;
            Carried.GetComponent<GrabItemOscar>().Carried = true;
        }
        else if(HangAbal == true)
        {
            Hangging = true;
        }
    }

    public void ThrowItem()
    {
        if(Carried != null)
        {
            Vector3 Dir = new Vector3(1, 1, 1);
            if (transform.localScale.x < 0) { Dir.x = -1; }
            Carried.GetComponent<Rigidbody2D>().velocity = ThrowVec * Dir;
            if (Carried.GetComponent<GrabItemOscar>().MyType == GrabItemOscar.GrabType.Barrel) { Carried.GetComponent<GrabItemOscar>().Thrown = true; }
            Carried = null;
        }
    }

    //Death
    public void PlayerDeath()
    {
        LvMan.GoToScene(2);
    }

    //Grafics for visualization
    private void OnDrawGizmosSelected()
    {
        //ground detector
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(GroundPoint.transform.position, 0.08f);
        Gizmos.DrawWireSphere(CanonPoint.transform.position, AtkRadius*2);
        //punch
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(CanonPoint.position, AtkRadius);
        Gizmos.DrawWireSphere(GroundPoint.transform.position, 0.3f);
    }
}
