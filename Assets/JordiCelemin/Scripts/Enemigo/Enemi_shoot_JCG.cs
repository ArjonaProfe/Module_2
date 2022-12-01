using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemi_shoot_JCG : MonoBehaviour
{
    public Transform player_pos;
    public float speed;
  
    private Rigidbody2D rb;
    private Animator anim;
    public Transform punto_instancia;
    public GameObject bala;
    private float tiempo;
    // Start is called before the first frame update
    void Start()
    {
        player_pos = GameObject.Find("Manolo").transform;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //movimiento
       
        //flip X
        if(player_pos.position.x>this.transform.position.x)
        {
            this.transform.localScale = new Vector2(1, 1);
        }
        else
        {
            this.transform.localScale = new Vector2(-1, 1);
        }

        //disparo
        tiempo += Time.deltaTime;
        {
            if (tiempo >= 2)
            {
                Instantiate(bala, punto_instancia.position, Quaternion.identity);
                tiempo = 0;
            }
        }
       
    }
}
