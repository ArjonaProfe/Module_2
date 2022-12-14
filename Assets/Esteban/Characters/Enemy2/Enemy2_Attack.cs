using System.Collections;
using UnityEngine;

public class Enemy2_Attack : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed = 1.8f;
    [SerializeField] private Transform attackToPoint;
    [SerializeField] private float waitTime = 10f;
    [SerializeField] private float startWaitTime = 10f;
    private bool mirandoDerecha;
    private bool isMovingBack;
    public bool comienzaCuentaAtras;
    private Vector2 posicionInicial;
    private Animator animator;
    private ProgressBarravida_Es barraProgresovida;
    void Start()
    {
        posicionInicial = transform.position;
        animator = GetComponent<Animator>();
        rb= GetComponent<Rigidbody2D>();
        barraProgresovida = transform.Find("CanvasProgresoVida").GetComponent<ProgressBarravida_Es>();

    }

    // Update is called once per frame
    void Update()

    {
       
        //Debug.Log("velocidad x" + rb.velocity.x * Time.fixedDeltaTime * speed);
        //Debug.Log("parent " + transform.parent.position);
        //Debug.Log("attackposition  " + attackToPoint.transform.position.x);
        // Debug.Log("forward " + transform.forward.x);

        if (!isMovingBack)
        {
            speed = 4;
            animator.SetBool("run", true);
            comienzaCuentaAtras = false;
            //Debug.Log("pasa2");
            transform.position = Vector2.MoveTowards(transform.position, attackToPoint.transform.position,
            speed * Time.deltaTime);
            //isMovingBack = true;

        }
        if (Mathf.Abs(transform.position.x) == attackToPoint.transform.position.x)
        {
            //Debug.Log("play attack");
            animator.Play("attack_Enemy2");
            StartCoroutine(Girando());

        }
        if (Mathf.Abs(transform.position.x) == attackToPoint.transform.position.x || isMovingBack)
        {
            speed = 1.8f;
            //Debug.Log("pasa1");
            transform.position = Vector2.MoveTowards(transform.position, posicionInicial,
            speed * Time.deltaTime);
            isMovingBack = true;


        }
        if (Mathf.Abs(transform.position.x) == posicionInicial.x)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            animator.SetBool("run", false);
            comienzaCuentaAtras = true;
            StartCoroutine(Girando());
            //isMovingBack = false;
        }
        if (comienzaCuentaAtras)
        {
            if (waitTime <= 0)
            {
                rb.constraints &= RigidbodyConstraints2D.FreezePositionX;
                rb.constraints = RigidbodyConstraints2D.FreezePositionY;
                waitTime = startWaitTime;
                isMovingBack = false;
                comienzaCuentaAtras = false;

            }
            else
            {

                waitTime -= Time.deltaTime;

            }
        }
        //if (transform.position.x == attackToPoint.transform.position.x || isMovingBack)
        //{
        //    transform.position = Vector2.MoveTowards(attackToPoint.transform.position, new Vector3(0, 0, 0),
        //    speed * Time.deltaTime);
        //    isMovingBack = true;
        //}
        //if (transform.position.x >= 0)
        //{
        //    isMovingBack = false;
        //}

    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    Debug.Log(collision.name);
    //    if (collision.name == "AttackToPoint")
    //    {
    //        Debug.Log(collision.name);
    //    }
    //}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.gameObject.name);

        if (collision.gameObject.name == "Norbut")
        {
            //Debug.Log(collision.gameObject.name);
            Transform transformCircle = collision.gameObject.transform.Find("Circle");
            BlockFlash blockFlashBool = transformCircle.gameObject.GetComponent<BlockFlash>();
            if (!blockFlashBool.BlockFlashBool)
            {
                animator.Play("attack_Enemy2");
                collision.gameObject.GetComponent<PlayerMovement_Es>().Damage(5);
            }
        }
    }

    public void Girar()
    {
        mirandoDerecha = !mirandoDerecha;
        transform.localScale = new Vector3(transform.localScale.x * -1,
            transform.localScale.y, transform.localScale.z);
        barraProgresovida.transform.Find("ProgressVida").transform.eulerAngles =
        new Vector3(0, barraProgresovida.transform.Find("ProgressVida").transform.eulerAngles.y - 180, 0);
    }

    IEnumerator Girando()
    {
        float trA = transform.position.x;
        yield return new WaitForSeconds(0.1f);
        if (trA < transform.position.x && !mirandoDerecha)
        {
            Invoke("Girar", 0.3f);
            //Girar();

        }
        if (trA > transform.position.x - 1f && mirandoDerecha)
        {
            Girar();

        }
        yield return null;
    }




}
