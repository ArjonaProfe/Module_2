using System;
using System.Collections;
using UnityEngine;

public class Enemy3_Attack : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    public Transform attackToPoint;
    [SerializeField] private float waitTime = 5f;
    [SerializeField] private float startWaitTime = 5f;
    private bool isMoving;
    private bool isMovingBack;
    public bool comienzaCuentaAtras;
    private Vector2 posicionInicial;
    private Animator animator;
    private Rigidbody2D rb;
    private float distanciaEntreEnemigo2_Enemigo3;
    private bool mirandoDerecha;
    private ProgressBarravida_Es barraProgresovida;
    private String norbutName = "Norbut";
    private String scorpionName = "scorpion";
    private Transform scorpionTransform;



    void Start()
    {
        scorpionTransform = GameObject.Find(scorpionName).transform;
        posicionInicial = transform.position;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        barraProgresovida = transform.Find("CanvasProgresoVida").GetComponent<ProgressBarravida_Es>();
        if (attackToPoint == null)
        {
            attackToPoint = GameObject.Find(norbutName).transform;

        }
    }

    // Update is called once per frame
    void Update()

    {

        Vector2 posicionEnemy3 = transform.position;
        Vector2 posicionScorpion = scorpionTransform.position;// en este caso es el superenemigo
        float x1 = posicionEnemy3.x, x2 = posicionScorpion.x, y1 = posicionEnemy3.y, y2 = posicionScorpion.y;
        // Distance between X coordinates
        float xDif = Mathf.Abs(Mathf.Max(x1, x2) - Mathf.Min(x1, x2));
        // Distance between Y coordinates
        float yDif = Mathf.Abs(Mathf.Max(y1, y2) - Mathf.Min(y1, y2));
        // Pythagorean theorem
        float finalDistance = Mathf.Sqrt(xDif * xDif + yDif * yDif);
        if (finalDistance > 2)
        {
            rb.simulated = true;
        }
        if (!isMovingBack)
        {
            speed = 1;
            animator.SetBool("run", true);
            comienzaCuentaAtras = false;
            //Debug.Log("pasa2");
            //transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, playerPos.y, transform.position.z), step);
            transform.position = Vector2.MoveTowards(transform.position,
                new Vector2(attackToPoint.transform.position.x, transform.position.y),
                speed * Time.deltaTime);
            //isMovingBack = true;

        }
        if (Mathf.Abs(transform.position.x) == Mathf.Abs(attackToPoint.transform.position.x))
        {
            //Debug.Log("play attack");
            //rb.simulated = true;
            animator.Play("attack_Enemy3");
            StartCoroutine(Girando());
        }
        if (Mathf.Abs(transform.position.x) == attackToPoint.transform.position.x || isMovingBack)
        {
            speed = 1f;
            //Debug.Log("pasa1");

            posicionInicial.y = -15f;
            transform.position = Vector2.MoveTowards(transform.position, posicionInicial,
            speed * Time.deltaTime);
            isMovingBack = true;
        }
        if (Mathf.Abs(transform.position.x) == posicionInicial.x)
        {
            animator.SetBool("run", false);
            comienzaCuentaAtras = true;
            StartCoroutine(Girando());
            //isMovingBack = false;
        }
        if (comienzaCuentaAtras)
        {
            if (waitTime <= 0)
            {

                waitTime = startWaitTime;
                isMovingBack = false;
                comienzaCuentaAtras = false;
            }
            else
            {
                waitTime -= Time.deltaTime;
                //isMovingBack = true;
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
                animator.Play("attack_Enemy3");
                collision.gameObject.GetComponent<PlayerMovement_Es>().Damage(2);
            }
        }
        if (collision.gameObject.name == "scorpion" || collision.gameObject.name == "scorpionMini")
        {
            rb.simulated = false;
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            //transform.GetComponent<Collider2D>().isTrigger = true;
        }


    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Norbut")
        {
            //Debug.Log(collision.gameObject.name);
            Transform transformCircle = collision.gameObject.transform.Find("Circle");
            BlockFlash blockFlashBool = transformCircle.gameObject.GetComponent<BlockFlash>();
            if (!blockFlashBool.BlockFlashBool)
            {
                animator.Play("attack_Enemy3");
                collision.gameObject.GetComponent<PlayerMovement_Es>().Damage(2);
            }
        }
        if (collision.gameObject.name == "scorpion" || collision.gameObject.name == "scorpionMini")
        {
            rb.simulated = false;
            //transform.GetComponent<Collider2D>().isTrigger = true;
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

