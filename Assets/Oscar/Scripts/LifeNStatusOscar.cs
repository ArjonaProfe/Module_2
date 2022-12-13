using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeNStatusOscar : MonoBehaviour
{
    public enum Faction { Hero, Neutral, Villain }
    public Faction MyFaction;
    public int Life, MaxLife, StunBuild, StunGoal;
    public bool Shield, ExpShield, JustHurted;
    public Animator Anim;
    public enum DmgType { Weak, Strong, Explosive, Fire }

    // Start is called before the first frame update
    void Start()
    {
        Life = MaxLife;
        JustHurted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Life <= 0)
        {
            if(Anim != null) { Anim.SetTrigger("Death"); }
            else { Death(); }
        }

        if (Input.GetKeyDown(KeyCode.H)) { TakeDamage(10, DmgType.Weak); }
    }

    public void TakeDamage(int Dmg, DmgType Type)
    {
        switch (Type)
        {
            case DmgType.Weak:
                if(Shield == false && ExpShield == false)
                {
                    Life -= Dmg;
                    if (Anim != null)
                    {
                        StunBuild += Dmg;
                        if (StunBuild >= StunGoal)
                        {
                            Anim.SetTrigger("Hurt");
                            StunBuild = 0;
                        }
                    }
                    JustHurted = true;
                }
                break;
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
                            if (StunBuild >= StunGoal)
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
                            if (StunBuild >= StunGoal)
                            {
                                Anim.SetTrigger("Hurt");
                                StunBuild = 0;
                            }
                        }
                        JustHurted = true;
                    }
                }
                break;
            case DmgType.Explosive:
                if (ExpShield == true)
                {
                    Life -= Dmg;
                    ExpShield = false;
                    Shield = false;
                    if (Anim != null)
                    {
                        StunBuild += Dmg;
                        if (StunBuild >= StunGoal)
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
                        if (StunBuild >= StunGoal)
                        {
                            Anim.SetTrigger("Hurt");
                            StunBuild = 0;
                        }
                    }
                    JustHurted = true;
                }
                break;
            case DmgType.Fire:
                if (Shield == false && ExpShield == false)
                {
                    Life -= Dmg;
                    if (Anim != null)
                    {
                        StunBuild += Dmg;
                        if (StunBuild >= StunGoal)
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
