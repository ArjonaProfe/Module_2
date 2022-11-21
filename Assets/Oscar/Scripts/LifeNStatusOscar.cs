using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeNStatusOscar : MonoBehaviour
{
    public enum Faction { Hero, Neutral, Villain }
    public Faction MyFaction;
    public int Life, MaxLife;
    public bool Shield;
    public Animator Anim;

    // Start is called before the first frame update
    void Start()
    {
        Life = MaxLife;
    }

    // Update is called once per frame
    void Update()
    {
        if(Life <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int Dmg, bool Potent)
    {
        if(Shield == true)
        {
            if(Potent == true)
            {
                Life -= Dmg;
                Shield = false;
            }
            else
            {
                //not damage
            }
        }
        else
        {
            Life -= Dmg;
        }
    }
}
