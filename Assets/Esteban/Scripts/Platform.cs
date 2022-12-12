using UnityEngine;

public class Platform : MonoBehaviour
{
    private PlatformEffector2D effector2D;
    [SerializeField] private float tiempoDeRetardo;//tiempo de retardo para bajar de la plataforma
    public float retardo;//tiempo de retardo transcurrido
    void Start()
    {
        effector2D = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (retardo < tiempoDeRetardo)
        {
            retardo -= Time.deltaTime;//continua la cuenta atrás
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            retardo = tiempoDeRetardo;
            retardo -= Time.deltaTime;//comienza la cuenta atrás

        }
        if (retardo <= 0)//si ha pasado el tiempo transcurrido rota para bajar
        {
            effector2D.rotationalOffset = 180f;
            retardo = tiempoDeRetardo;//se resetea el tiempo transcurrido 
        }
        if (Input.GetKey("space"))
        {
            effector2D.rotationalOffset = 0f;//vuelve a su posción normal 
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        effector2D.rotationalOffset = 0f;//vuelve a su posción normal 
    }
  
}
