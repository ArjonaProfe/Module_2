using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowserntControlOscar : MonoBehaviour
{
    //Other scrpts
    public LifeNStatusOscar LifeMan;
    public Rigidbody2D RB2D;
    public Animator Anim;
    public LevelManagerOscar LvMan;

    //Detections
    public GameObject Target;
    public Transform GroundPoint, FrontGroundPoint, CanonPoint1, CanonPoint2, CealingPoint;
    public List<Transform> BreakPlats;
    public LayerMask IsGround, IsEnemy;
    public bool Grounded, FrontGrounded;
    public float TarDist;

    //State machine
    public int State, CurrState;
    public List<int> Patern;
    public float Timer;
    public int Uses;

    //Props
    public GameObject Wave, Bullet, Rainshot, RainBomb;
    public int WaveDmg, BulletDmg;

    //Firerain
    public int RainDmg, RainAngle, RainDist, RainAmmo;
    public List<GameObject> Meteors;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Detections
        Grounded = Physics2D.OverlapCircle(GroundPoint.position, 0.05f, IsGround);
        Anim.SetBool("Grounded", Grounded);
        FrontGrounded = Physics2D.OverlapCircle(FrontGroundPoint.position, 0.05f, IsGround);
        TarDist = Vector2.Distance(transform.position, Target.transform.position);

        //States
        Anim.SetInteger("State", State);
        switch (State)
        {
            case 0:
                if(TarDist < 26)
                {
                    Timer += Time.deltaTime;
                    if(Timer >= 1)
                    {
                        NextMove();
                        Timer = 0;
                    }
                }
                Uses = 0;
                break;
            case 1:
                if(FrontGrounded == false) { State = 0; }
                break;
            case 2:
                //Return to 0 in the landing function
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
            default:
                break;
        }

        //Calculate the nearest platform to the player

    }

    public void NextMove()
    {
        State = Patern[CurrState];
        CurrState += 1;
        if (CurrState >= Patern.Count) { CurrState = 0; }
        Uses = 0;
        Meteors.Clear();
    }

    public void MeleeAtk()
    {
        Collider2D[] EnemiesToDamage = Physics2D.OverlapCircleAll(CanonPoint1.transform.position, 1, IsEnemy);
        for (int i = 0; i < EnemiesToDamage.Length; i++)
        {
            if (EnemiesToDamage[i].GetComponent<LifeNStatusOscar>() != null && EnemiesToDamage[i].GetComponent<LifeNStatusOscar>().MyFaction != LifeMan.MyFaction)
            {
                EnemiesToDamage[i].GetComponent<LifeNStatusOscar>().TakeDamage(10, LifeNStatusOscar.DmgType.Strong);
                if (EnemiesToDamage[i].GetComponent<Rigidbody2D>() != null)
                {
                    Vector3 Dir = new Vector3(1, 1, 1);
                    if (transform.localScale.x < 0) { Dir.x = -1; }
                    //EnemiesToDamage[i].GetComponent<Rigidbody2D>().velocity = Vector3.Scale(PushDir, Dir);
                }
            }
        }
    }

    public void PotentJump()
    {
        Collider2D[] EnemiesToDamage = Physics2D.OverlapCircleAll(GroundPoint.transform.position, 0.5f, IsEnemy);
        for (int i = 0; i < EnemiesToDamage.Length; i++)
        {
            if (EnemiesToDamage[i].GetComponent<LifeNStatusOscar>().MyFaction != LifeMan.MyFaction)
            {
                EnemiesToDamage[i].GetComponent<LifeNStatusOscar>().TakeDamage(10, LifeNStatusOscar.DmgType.Strong);
            }
        }
        RB2D.velocity = new Vector3(0, 30, 0);
    }

    public void PotentLanding()
    {
        GameObject WaveR = Instantiate(Wave, GroundPoint.transform.position + new Vector3(0, 0.5f, 0), Quaternion.Euler(0, 0, 0));
        WaveR.GetComponent<BulletOscar>().MyFaction = LifeMan.MyFaction;
        GameObject WaveL = Instantiate(Wave, GroundPoint.transform.position + new Vector3(0, 0.5f, 0), Quaternion.Euler(0, 0, 180));
        WaveL.GetComponent<BulletOscar>().MyFaction = LifeMan.MyFaction;
        State = 0;
    }

    public void ShotAltShot(int Bar)
    {
        Vector3 Dir = new Vector3(0, 0, 0);
        if (transform.localScale.x < 0) { Dir.y = 180; }
        if (Bar == 0)
        {
            GameObject NewShot = Instantiate(Bullet, CanonPoint1.transform.position, Quaternion.Euler(Dir));
            NewShot.GetComponent<BulletOscar>().MyFaction = LifeMan.MyFaction;
            NewShot.GetComponent<BulletOscar>().Power = BulletDmg;
        }
        else
        {
            GameObject NewShot = Instantiate(Bullet, CanonPoint2.transform.position, Quaternion.Euler(Dir));
            NewShot.GetComponent<BulletOscar>().MyFaction = LifeMan.MyFaction;
            NewShot.GetComponent<BulletOscar>().Power = BulletDmg;
        }
        Uses += 1;
        if(Uses > 6) { Uses = 0;  State = 0; }
    }

    public void FireRainPre()
    {
        for (int i = 0; i < RainAmmo; i++)
        {
            int angle = (RainAngle * (RainAmmo - 1) / 2) - RainAngle * i;
            GameObject NewPellet = Instantiate(Rainshot, CanonPoint2.position, Quaternion.Euler(0, 0, angle + 90));
            NewPellet.GetComponent<BulletOscar>().MyFaction = LifeMan.MyFaction;
            NewPellet.GetComponent<BulletOscar>().Power = RainDmg;
        }
    }
    public void FireRainTrue()
    {
        for (int i = 0; i < RainAmmo; i++)
        {
            GameObject NewPellet = Instantiate(Rainshot, CealingPoint.position + new Vector3((RainAmmo - 1) * RainDist / 2 - i * RainDist, Random.Range(-3, 3), 0), Quaternion.Euler(0, 0, -90));
            NewPellet.GetComponent<BulletOscar>().MyFaction = LifeMan.MyFaction;
            NewPellet.GetComponent<BulletOscar>().Power = RainDmg;
        }
        State = 0;
    }

    public void BombRain()
    {
        for (int i = 0; i < RainAmmo; i++)
        {
            GameObject NewPellet = Instantiate(RainBomb, CealingPoint.position + new Vector3((RainAmmo - 1) * RainDist / 2 - i * RainDist, Random.Range(-3, 3), 0), Quaternion.Euler(0, 0, -90));
            NewPellet.GetComponent<DetonMeteorOscar>().MyFaction = LifeMan.MyFaction;
            NewPellet.GetComponent<DetonMeteorOscar>().Power = RainDmg;
            Meteors.Add(NewPellet);
        }
    }

    public void DetonPunch()
    {
        for (int i = 0; i < Meteors.Count; i++)
        {
            Meteors[i].GetComponent<DetonMeteorOscar>().Deton();
        }
        Meteors.Clear();
        State = 0;
    }

    //Level Complere when killed
    public void LVClearOnDefeat()
    {
        LvMan.LevelClear();
    }

    //Grafics for visualization
    private void OnDrawGizmosSelected()
    {
        //ground detector
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(GroundPoint.transform.position, 0.08f);
        Gizmos.DrawWireSphere(CanonPoint2.transform.position,  1);
        //punch
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(CanonPoint1.position, 1);
        Gizmos.DrawWireSphere(GroundPoint.transform.position, 0.3f);
    }
}
