using System.Collections;
using UnityEngine;

public class PlayerMovement_Es : MonoBehaviour
{
    [SerializeField] private float vida = 100f;
    [SerializeField] private float cantidadVidas = 4;
    private float xMovement;
    [SerializeField] private float speed;
    [Range(0f, 0.3f)][SerializeField] private float smoothMovement;
    private Vector3 velocidad = Vector3.zero;
    private bool mirandoDerecha = true;
    private Rigidbody2D rb;
    private AnimManager_Es anim1;
    public SpriteRenderer spriteRenderer;
    private AtaquePlayer ataqueEspada;
    [Header("Saltar")]
    [SerializeField] private float fuerzaSalto;
    [SerializeField] private LayerMask queEsSuelo;
    [SerializeField] private Transform controladorSuelo;
    [SerializeField] private Vector3 dimensionesCaja;
    [SerializeField] private bool enSuelo;
    private bool salto = false;
    private BlockFlash blockFlashBool;



    public float XMovement { get => xMovement; set => xMovement = value; }
    public bool EnSuelo { get => enSuelo; set => enSuelo = value; }
    public float Vida { get => vida; set => vida = value; }
    public BlockFlash BlockFlashBool { get => blockFlashBool; set => blockFlashBool = value; }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim1 = GetComponent<AnimManager_Es>();
        ataqueEspada = GetComponent<AtaquePlayer>();
        Transform transformCircle = gameObject.transform.Find("Circle");
        blockFlashBool = transformCircle.gameObject.GetComponent<BlockFlash>();
        

    }
    void Update()
    {
        xMovement = Input.GetAxisRaw("Horizontal") * speed;
        if (Input.GetButtonDown("Jump"))
        {
            salto = true;
        }
    }
    private void FixedUpdate()
    {
        enSuelo = Physics2D.OverlapBox(controladorSuelo.position, dimensionesCaja, 0f, queEsSuelo);
        Mover(xMovement * Time.fixedDeltaTime);
        Jump(salto);
        salto = false;
    }
    public void Mover(float mover)
    {
        Vector2 speedObject = new Vector2(mover, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, speedObject, ref velocidad, smoothMovement);
        if (xMovement > 0 && !mirandoDerecha)
        {
            Girar();
        }
        else if (xMovement < 0 && mirandoDerecha)
        {
            Girar();
        }
    }
    public void Girar()
    {
        mirandoDerecha = !mirandoDerecha;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);

        /*Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;*/
    }
    public void Jump(bool saltar)
    {
        if (enSuelo && saltar)
        {
            enSuelo = false;
            rb.AddForce(new Vector2(0f, fuerzaSalto));
            //anim1.SaltarAnimacion();
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(controladorSuelo.position, dimensionesCaja);
    }
    public void Damage(float cantDamage)
    {
        vida -= cantDamage;
        if (vida <= 0)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
            rb.AddForce(new Vector2(XMovement * -1f, 0f));
            anim1.Muerte();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.collider.tag);
        Debug.Log(collision.gameObject.name);

        if (collision.collider.CompareTag("Enemy1") && blockFlashBool.BlockFlashBool == false)
        {
            Enemy1Damage_Es enemyDamage = collision.gameObject.GetComponent<Enemy1Damage_Es>();
            if (!enemyDamage.Muerto)
            {
                rb.AddForce(new Vector2(XMovement * -2f, 400f));
                gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
                Damage(10);

            }


        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.collider.CompareTag("Enemy1") && blockFlashBool.BlockFlashBool == false)
        {
            Enemy1Damage_Es enemyDamage = collision.gameObject.GetComponent<Enemy1Damage_Es>();
            if (!enemyDamage.Muerto)
            {
                StartCoroutine(ColorBlancoRojo());
            }

        }



    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy1"))
        {
            Enemy1Damage_Es enemyDamage = collision.gameObject.GetComponent<Enemy1Damage_Es>();
            if (!enemyDamage.Muerto)
            {
                gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        if (collision.CompareTag("Lava"))
        {
            Debug.Log("lava");
            Damage(100);
        }
        else if (collision.CompareTag("Fuego"))
        {
            StartCoroutine(ColorBlancoRojo());
            Debug.Log("Fuego");
            Damage(10);
        }
    }
    IEnumerator ColorBlancoRojo()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
        yield return new WaitForSeconds(0.5f);
        Damage(0.5f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Fuego"))
        {
            StartCoroutine(ColorBlancoRojo());
            Debug.Log("Fuego");
            Damage(1);
        }
    }

}