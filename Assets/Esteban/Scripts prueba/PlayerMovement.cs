using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    //public int firstNumber;
    //public int secondNumber;
    //public bool interruptor;
    //public GameObject cubeCharacer;
    public Transform rayOrigin;
    private float xMovement;
    public float speed = 1;
    public float jump = 10;
    private Rigidbody2D rb;
    private Animator anim;
    public bool attack;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame

    void Update()

    {
        DireccionJugador();   // Dirección del jugador según la variable "Horizontal" de preferencias
        IsGrounded();

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            attack = true;
            anim.SetBool("transAtaque1", attack);
        }
        //if (Input.GetKeyUp(KeyCode.E))
        //{
        //    anim.SetBool("transAtaque1", false);
        //}


    }

    public void DireccionJugador()
    {
        xMovement = Input.GetAxisRaw("Horizontal");
        Debug.Log(xMovement);
        rb.velocity = new Vector2(xMovement * speed, rb.velocity.y);
    }
    public void Jump()
    {
        if (IsGrounded())
        {
            rb.velocity = new Vector2(0, jump);
        }
    }
    public bool IsGrounded()
    {
        RaycastHit2D ray = Physics2D.Raycast(rayOrigin.position, Vector2.down, 10f);
        if (ray.distance < 0.01f)
        {
            return true;
        }
        return false;

    }
    //public void SetMovement(float x1, float y1)
    //{
    //    rb.velocity = new Vector2(x1, y1);
    //}
    //public void Saltar(float x1, float y1)
    //{
    //    rb.velocity = new Vector2(x1, y1);
    //}
}
