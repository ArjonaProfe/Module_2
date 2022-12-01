using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeNStatusOscar : MonoBehaviour
{
    public enum Faction { Hero, Neutral, Villain }
    public Faction MyFaction;
    public int Life, MaxLife, StunBuild, StunGoal;
    public bool Shield, JustHurted;
    public Animator Anim;

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

        if (Input.GetKeyDown(KeyCode.H)) { TakeDamage(10, false); }
    }

    public void TakeDamage(int Dmg, bool Potent)
    {
        if(Shield == true)
        {
            if(Potent == true)
            {
                Life -= Dmg;
                Shield = false;
                if(Anim != null)
                {
                    StunBuild += (int)((float)Dmg * 1.5f);
                    if(StunBuild >= StunGoal)
                    {
                        Anim.SetTrigger("Hurt");
                        StunBuild = 0;
                    }
                }
                JustHurted = true;
            }
            else
            {
                //not damage
                if (Anim != null) { Anim.SetTrigger("Hurt"); }
                JustHurted = true;
            }
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
