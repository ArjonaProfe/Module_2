using System.Collections;
using UnityEngine;

public class Enemy1Damage_Es : MonoBehaviour
{
    private AnimationManagerEnemy1_Es animationManagerEnemy;
    [SerializeField] private float vida = 200f;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private bool muerto;
    private Rigidbody2D rb;

    public bool Muerto { get => muerto; set => muerto = value; }

    void Start()
    {
        animationManagerEnemy = GetComponent<AnimationManagerEnemy1_Es>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Damage(int damage)
    {
        vida -= damage;
        //Debug.Log(vida);
        if (vida > 0)
        {
            StartCoroutine(ColorBlancoRojo());

            //spriteRenderer.color = new Color(255, 255, 255, (vida / (100 - damage)));

            //Debug.Log("VIDA DE OBJECT " + (vida / (100 - damage)));
        }
        else if (vida <= 0)
        {
            Muerte();
        }
    }
    public void Muerte()
    {
        muerto= true;
        animationManagerEnemy.Muerte();
        rb.simulated= false;
        //Debug.Log("Muerte");
        //Debug.Log(gameObject.tag);
        Destroy(transform.root.gameObject,1.2f);

    }
    IEnumerator ColorBlancoRojo()
    {
        yield return new WaitForSeconds(0.2f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
        yield return new WaitForSeconds(0.2f);        
        gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
    }


}
