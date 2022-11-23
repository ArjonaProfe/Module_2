using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlOscar : MonoBehaviour
{
    //Comunication with other scripts
    public LifeNStatusOscar LifeMan;
    public Animator Anim;
    public Rigidbody2D RB2D;

    //Stats
    public float JumpSpeed;
    public int MeleeDmg, CharMeleeDmg;
    public float CharTimer, CharGoal;

    //Detections
    public Transform GroundPoint;
    public bool Grounded;
    public LayerMask IsGround;

    public Transform CanonPoint;
    public float AtkRadius;
    public LayerMask IsEnemy, IsGizmo;

    //Fireball throw
    public GameObject FireProp;
    public int FirePow;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Moving
        float Move = Input.GetAxisRaw("Horizontal");
        if(Move != 0)
        {
            transform.localScale = new Vector3(4 * Move, 4, 1);
            Anim.SetBool("Running", true);
        }
        else { Anim.SetBool("Running", false); }

        //Ground detection and jump
        Grounded = Physics2D.OverlapCircle(GroundPoint.position, 0.05f, IsGround);
        Anim.SetBool("Grounded", Grounded);
        if (Input.GetButtonDown("Jump") && Grounded == true)
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

        if (Input.GetButtonDown("Fire2"))
        {
            Anim.SetTrigger("Fireball");
        }

        if(Input.GetAxisRaw("Vertical") < 0 && Grounded == false)
        {
            Anim.SetBool("GroundPound", true);
        }
        else { Anim.SetBool("GroundPound", false); }
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
        NewFire.GetComponent<BulletOscar>().Power = FirePow;
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
        Gizmos.DrawWireSphere(GroundPoint.transform.position, 0.3f);
    }
}
