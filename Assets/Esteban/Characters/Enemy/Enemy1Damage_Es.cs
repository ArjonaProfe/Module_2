using System.Collections;
using UnityEngine;

public class Enemy1Damage_Es : MonoBehaviour
{
    private AnimationManagerEnemy1_Es animationManagerEnemy;
    [SerializeField] private float vida = 30f;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private bool muerto;
    private Rigidbody2D rb;
    private PlayerMovement_Es playerMovement_Es;

    public bool Muerto { get => muerto; set => muerto = value; }

    void Start()
    {
        animationManagerEnemy = GetComponent<AnimationManagerEnemy1_Es>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        //blockFlash = GetComponent<BlockFlash>();
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
        muerto = true;
        animationManagerEnemy.Muerte();
        rb.simulated = false;
        //Debug.Log("Muerte");
        //Debug.Log(gameObject.tag);
        Transform salidaenemigo3Transform = GameObject.Find("SalidaEnemigo3").transform;
        Destroy(salidaenemigo3Transform.gameObject);
        Transform scorpionMiniTransform = GameObject.Find("scorpionMini").transform;
        Destroy(scorpionMiniTransform.gameObject);
        Transform sueloDestructible3 = GameObject.Find("SueloDestructible3").transform;
        SueloDestructible sueloDestructibleScript = sueloDestructible3.GetComponent<SueloDestructible>();
        sueloDestructibleScript.Autodestroy();
        Destroy(transform.root.gameObject, 1.2f);

    }
    IEnumerator ColorBlancoRojo()
    {
        yield return new WaitForSeconds(0.2f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
        yield return new WaitForSeconds(0.2f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Transform transformCircle = collision.gameObject.transform.Find("Circle");
            BlockFlash blockFlashBool = transformCircle.gameObject.GetComponent<BlockFlash>();
            
            if (blockFlashBool.BlockFlashBool)
            {
                Damage(10);
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Transform transformCircle = collision.gameObject.transform.Find("Circle");
            BlockFlash blockFlashBool = transformCircle.gameObject.GetComponent<BlockFlash>();
            if (blockFlashBool.BlockFlashBool)
            {
                Damage(10);
            }
        }
    }
}
