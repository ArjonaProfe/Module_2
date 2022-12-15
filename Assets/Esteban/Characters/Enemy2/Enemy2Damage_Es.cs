using System.Collections;
using UnityEngine;

public class Enemy2Damage_Es : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private float vida = 400f;
    private float vidaMaxima;
    private SpriteRenderer spriteRenderer;
    private bool muerto;    
    private PlayerMovement_Es playerMovement_Es;
    private ProgressBarravida_Es progressBarravida_Es;

    public bool Muerto { get => muerto; set => muerto = value; }

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        progressBarravida_Es= transform.Find("CanvasProgresoVida").GetComponent<ProgressBarravida_Es>();
        vidaMaxima = vida;        
        //blockFlash = GetComponent<BlockFlash>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Damage(int damage)
    {
        vida -= damage;
        progressBarravida_Es.setVidaActual(vida);
        progressBarravida_Es.setVidaMaxima(vidaMaxima);
        //Debug.Log(vida);
        if (vida > 0)
        {
            StartCoroutine(ColorBlancoRojo());
        }
        else if (vida <= 0)
        {
            Muerte();
        }
    }
    public void Muerte()
    {
        muerto = true;
        //animationManagerEnemy.Muerte();
        //rb.simulated = false;
        //Debug.Log("Muerte");
        //Debug.Log(gameObject.tag);
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
            Debug.Log("entra en enemigo2");
            Transform transformCircle = collision.gameObject.transform.Find("Circle");
            BlockFlash blockFlashBool = transformCircle.gameObject.GetComponent<BlockFlash>();

            if (blockFlashBool.BlockFlashBool)
            {
                Damage(1);
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
                Damage(1);
            }
        }
    }
}
