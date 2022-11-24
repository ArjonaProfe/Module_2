using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    //public int firstNumber;
    //public int secondNumber;
    //public bool interruptor;
    //public GameObject cubeCharacer;
    private BlockFlash blockFlash;
    public Transform rayOrigin;
    private float xMovement;
    public float speed = 1;
    public float jump = 10;
    private Rigidbody2D rb;
    private Animator anim1;
    
    public bool attack;
    public bool ataqueBlockFlash;

    void Start()
    {
        blockFlash = gameObject.AddComponent<BlockFlash>();
        rb = GetComponent<Rigidbody2D>();
        anim1 = GetComponent<Animator>();
        blockFlash.GetAnimator();

        //Debug.Log(blockFlash.name);
    }

    // Update is called once per frame

    void Update()

    {
        DireccionJugador();   // Dirección del jugador según la variable "Horizontal" de preferencias
        IsGrounded();
        attack = false;
        if (Input.GetButton("Jump"))
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {

            PararAtaque(true);
            //anim1.SetBool("transAtaque1", attack);
        }
        if (Input.GetButton("Fire2"))//tecla "R"
        {
            AtaqueBlockFlash();
        }

    }
    private void LateUpdate()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {

            PararAtaque(false);

        }
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
    private void PararAtaque(bool ataque)
    {
        anim1.SetBool("transAtaque1", ataque);
        attack = false;
    }
    private void AtaqueBlockFlash()
    {

        blockFlash.StopBlockFlash();

    }
}