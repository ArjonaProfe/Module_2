using UnityEngine;

public class Enemy2_Attack : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform attackToPoint;
    [SerializeField] private float waitTime = 10f;
    [SerializeField] private float startWaitTime = 10f;
    private bool isMoving;
    private bool isMovingBack;
    public bool comienzaCuentaAtras;
    private Vector2 posicionInicial;
    private Animator animator;
    void Start()
    {
        posicionInicial = transform.position;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()

    {
        //Debug.Log("parent " + transform.parent.position);
        //Debug.Log("attackposition  " + attackToPoint.transform.position.x);

        if (!isMovingBack)
        {
            speed= 4;
            animator.SetBool("run", true);
            comienzaCuentaAtras = false;
            //Debug.Log("pasa2");
            transform.position = Vector2.MoveTowards(transform.position, attackToPoint.transform.position,
            speed * Time.deltaTime);
            //isMovingBack = true;

        }
        if (Mathf.Abs(transform.position.x) == attackToPoint.transform.position.x )
        {
            //Debug.Log("play attack");
            animator.Play("attack_Enemy2");
        }
            if (Mathf.Abs(transform.position.x) == attackToPoint.transform.position.x || isMovingBack)
        {
            speed=2;
            //Debug.Log("pasa1");
            transform.position = Vector2.MoveTowards(transform.position, posicionInicial,
            speed * Time.deltaTime);
            isMovingBack = true;
        }
        if (Mathf.Abs(transform.position.x) == posicionInicial.x)
        {
            animator.SetBool("run", false);
            comienzaCuentaAtras = true;
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
            Debug.Log(collision.gameObject.name);
            animator.Play("attack_Enemy2");
        }
    }

}
