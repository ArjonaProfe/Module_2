using System.Collections;
using UnityEngine;

public class Enemy3Damage_Es : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private float vida = 30f;
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
        progressBarravida_Es = transform.Find("CanvasProgresoVida").GetComponent<ProgressBarravida_Es>();
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
        animator.Play("dead_Enemy3");

        //transform.GetComponent<Collider2D>().isTrigger = true;
        Invoke("DestroyAndReborn", 1.1f);
        

        //rb.simulated = false;
        //Debug.Log("Muerte");
        //Debug.Log(gameObject.tag);


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
            Debug.Log("entra en enemigo 3");
            Transform transformCircle = collision.gameObject.transform.Find("Circle");
            BlockFlash blockFlashBool = transformCircle.gameObject.GetComponent<BlockFlash>();

            if (blockFlashBool.BlockFlashBool)
            {
                Debug.Log("BlockFlash no hace daño al enemigo 3, solo le protege");
                //Damage(1);
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
                Debug.Log("BlockFlash no hace daño al enemigo 3, solo le protege");
                //Damage(1);
            }
        }
    }
    private void DestroyAndReborn()
    {
        Transform salida = GameObject.Find("SalidaEnemigo3").transform;
        Debug.Log("myRoot " + salida.name);
        Debug.Log("Parent " + transform.parent.name);
        //Instantiate(transform.parent.gameObject, myRoot.position, Quaternion.identity);
        Enemy3Instancia enemy3Instancia = salida.GetComponent<Enemy3Instancia>();
        enemy3Instancia.CrearEnemy3();
        muerto = false;
        Destroy(gameObject);
        Destroy(transform.parent.gameObject);

        //gameObject.SetActive(false);
        //transform.root.SetParent(transform);
        //gameObject.SetActive(true);

        //gameObject.transform.Translate(transform.root.position - transform.position, Space.World);
        //gameObject.SetActive(true);
        //vida = 30f;
    }
}
