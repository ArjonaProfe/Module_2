using System.Collections;
using UnityEngine;

public class AIBasic_Es : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool mirandoDerecha = true;
    private AnimationManagerEnemy1_Es animationManagerEnemy1;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float speed_ = 0.5f;
    private float waitTime;
    [SerializeField] private float startWaitTime = 2f;
    private int i = 0;
    private Vector2 actualPosition;
    [SerializeField] private Transform[] moveSpots;
    private bool detectado;

    public float Speed_ { get => speed_; set => speed_ = value; }
    public bool Detectado { get => detectado; set => detectado = value; }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        waitTime = startWaitTime;
        animationManagerEnemy1 = GetComponent<AnimationManagerEnemy1_Es>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {

        if (!detectado)
        {
            
            StartCoroutine(CheckEnemyMovint());
            //Debug.Log(rb.velocity);
            transform.position = Vector2.MoveTowards(transform.position, moveSpots[i].transform.position,
          speed_ * Time.deltaTime);

        }
        else
        {
            
            Transform norbutTransform = GameObject.Find("Norbut").transform;
            Debug.Log("tendría que seguir a Norbut" + norbutTransform.position);
            Debug.Log("detectado " + detectado);
            StartCoroutine(CheckEnemyMovint());
            transform.position = Vector2.MoveTowards(transform.position, norbutTransform.position,
          speed_ * Time.deltaTime);


        }

        if (Vector2.Distance(transform.position, moveSpots[i].transform.position) < 0.1f)
        {
            if (waitTime <= 0)
            {
                animationManagerEnemy1.Blink(false);
                if (moveSpots[i] != moveSpots[moveSpots.Length - 1])
                {
                    i++;
                }
                else
                {
                    i = 0;
                }
                waitTime = startWaitTime;
            }
            else
            {
                animationManagerEnemy1.Blink(true);

                waitTime -= Time.deltaTime;
            }
        }
    }
    IEnumerator CheckEnemyMovint()

    {
        actualPosition = transform.position;

        yield return new WaitForSeconds(0.5f);

        if (transform.position.x < actualPosition.x && mirandoDerecha)
        {
            //spriteRenderer.flipX = true;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);

            mirandoDerecha = !mirandoDerecha;

        }
        else if (transform.position.x > actualPosition.x && mirandoDerecha == false)
        {
            //spriteRenderer.flipX = false;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);

            mirandoDerecha = true;

        }




    }
}
