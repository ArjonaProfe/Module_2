using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    //public int firstNumber;
    //public int secondNumber;
    //public bool interruptor;
    //public GameObject cubeCharacer;
    public float speed = 1;
    public float jump = 6;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    void Update()
    {

        if (Input.GetKey(KeyCode.D))
        {
            SetMovement(speed, 0);
            Debug.Log($"Velocidad de rb = {rb.velocity.x}");
            Debug.Log("Letra D presionada");
            if (Input.GetKey(KeyCode.D) && Input.GetButtonDown("Jump"))
            {
                Saltar(rb.velocity.x * speed, jump);
                //rb.AddForce(new Vector2(rb.velocity.x * speed, jump));
                Debug.Log($"VALOR DE  jump = {jump}");
                //Debug.Log($"Valor de speed = {speed}");
                Debug.Log($"Letra presionada = {Input.GetButtonDown("Jump")}");
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            SetMovement(-speed, 0);
            Debug.Log($"Velocidad de rb en X = {rb.velocity.x}");
            Debug.Log("Letra A presionada");
            if (Input.GetButtonDown("Jump"))
            {
                Saltar(rb.velocity.x, jump);
                Debug.Log($"VALOR DE  jump = {jump}");
                Debug.Log($"Letra presionada = {Input.GetButtonDown("Jump")}");
            }
        }
        //if (Input.GetKey(KeyCode.S))
        //{
        //    setMovement(0, 0, -speed);
        //    Debug.Log($"Velocidad de rb en X = {rb.velocity.x}");
        //    //Debug.Log($"Valor de speed = {speed}");
        //    Debug.Log("Letra S presionada");
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    setMovement(speed, 0, 0);
        //    Debug.Log($"Velocidad de rb en X = {rb.velocity.x}");
        //    //Debug.Log($"Valor de speed = {speed}");
        //    Debug.Log("Letra D presionada");
        //}

        //if (Input.GetButtonDown("Jump"))
        //{
        //    Saltar(0, jump);
        //    //rb.velocity = new Vector2(0, jump);
        //    Debug.Log($"Velocidad de rb en y = {rb.velocity.y}");
        //    Debug.Log($"Valor de speed = {speed}");
        //    Debug.Log($"Letra presionada = {Input.GetButtonDown("Jump")}");
        //}

    }
    public void SetMovement(float x1, float y1)
    {
        rb.velocity = new Vector2(x1, y1);
    }
    public void Saltar(float x1, float y1)
    {
        rb.velocity = new Vector2(x1, y1);
    }
}
//if (Input.GetKey(KeyCode.D))   
//{
//    rb.velocity = new Vector3(0, speed, speed);
//    Debug.Log($"Letra W y D presionadas a velocity.y =   {rb.velocity.y}"  + $" speed=  {speed}" );
//}