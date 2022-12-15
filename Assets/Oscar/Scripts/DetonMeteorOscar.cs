using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetonMeteorOscar : MonoBehaviour
{
    public int Power;
    public float Speed, Lifetime;
    public LifeNStatusOscar.DmgType Potency;
    public LifeNStatusOscar.Faction MyFaction;
    public int Phase;
    public GameObject Bomb;

    // Start is called before the first frame update
    void Start()
    {
        Phase = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Moving in the direction it is facing (can be redirected by rotation)
        if(Phase == 0) { transform.position += transform.right * Speed * Time.deltaTime; }
        //Destroyed if it exist for too long
        Destroy(gameObject, Lifetime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Phase = 1;
        print("Impacto");
    }

    public void Deton()
    {
        GameObject Boom = Instantiate(Bomb, transform.position, Quaternion.identity);
        Boom.GetComponent<GrabItemOscar>().Anim.SetBool("Carried", true);
        Destroy(gameObject);
    }
}
