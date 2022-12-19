using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeNStatusOscar : MonoBehaviour
{
    public enum Faction { Hero, Neutral, Villain }
    public Faction MyFaction;
    public int Life, MaxLife, StunBuild, StunGoal;
    public bool Shield, ExpShield, JustHurted, Dead;
    public Animator Anim;
    public enum DmgType { Weak, Strong, Explosive, Fire }

    // Start is called before the first frame update
    void Start()
    {
        Life = MaxLife;
        JustHurted = false;
        Dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Life <= 0)
        {
            if(Anim != null) { Anim.SetTrigger("Death"); }
            else { Death(); }
            Dead = true;
        }
    }

    public void TakeDamage(int Dmg, DmgType Type)
    {
        //Diferent reaction depending on the damege type and the protections the user has
        switch (Type)
        {
            //Weak damage is stropped by any protection
            case DmgType.Weak:
                if(Shield == false && ExpShield == false)
                {
                    Life -= Dmg;
                    if (Anim != null)
                    {
                        StunBuild += Dmg;
                        if (StunBuild >= StunGoal && Dead == false)
                        {
                            Anim.SetTrigger("Hurt");
                            StunBuild = 0;
                        }
                    }
                    JustHurted = true;
                }
                break;
            //Strong damage destrois shields, but not explosion shields
            case DmgType.Strong:
                if(ExpShield == false)
                {
                    if (Shield == true)
                    {
                        Life -= Dmg;
                        Shield = false;
                        if (Anim != null)
                        {
                            StunBuild += Dmg;
                            if (StunBuild >= StunGoal && Dead == false)
                            {
                                Anim.SetTrigger("Hurt");
                                StunBuild = 0;
                            }
                        }
                        JustHurted = true;
                    }
                    else
                    {
                        Life -= Dmg;
                        if (Anim != null)
                        {
                            StunBuild += Dmg;
                            if (StunBuild >= StunGoal && Dead == false)
                            {
                                Anim.SetTrigger("Hurt");
                                StunBuild = 0;
                            }
                        }
                        JustHurted = true;
                    }
                }
                break;
            //Explosion damage alwais causes damage and destrois both types of shield
            case DmgType.Explosive:
                if (ExpShield == true)
                {
                    Life -= Dmg;
                    ExpShield = false;
                    Shield = false;
                    if (Anim != null)
                    {
                        StunBuild += Dmg;
                        if (StunBuild >= StunGoal && Dead == false)
                        {
                            Anim.SetTrigger("Hurt");
                            StunBuild = 0;
                        }
                    }
                    JustHurted = true;
                }
                else
                {
                    Life -= Dmg;
                    if (Anim != null)
                    {
                        StunBuild += Dmg;
                        if (StunBuild >= StunGoal && Dead == false)
                        {
                            Anim.SetTrigger("Hurt");
                            StunBuild = 0;
                        }
                    }
                    JustHurted = true;
                }
                break;
            //In practice fire is equal to weak damage...
            case DmgType.Fire:
                if (Shield == false && ExpShield == false)
                {
                    Life -= Dmg;
                    if (Anim != null)
                    {
                        StunBuild += Dmg;
                        if (StunBuild >= StunGoal && Dead == false)
                        {
                            Anim.SetTrigger("Hurt");
                            StunBuild = 0;
                        }
                    }
                    JustHurted = true;
                }
                break;
            default:
                break;
        }
    }

    public void Heal(int HealAmount)
    {
        Life += HealAmount;
        if(Life > MaxLife) { Life = MaxLife; }
    }

    public void Death()
    {
        Destroy(gameObject);
    }
}
