using UnityEngine;

public class Disparo : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private int daño;
    private Animator animatorHit;
    private GameObject hitgameObject;
    void Start()
    {
        hitgameObject = gameObject.transform.Find("animHit").gameObject;
        animatorHit = hitgameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * velocidad * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("ontriggerEnter disparo");
        if (collision.CompareTag("Enemy1"))
        {
            collision.gameObject.GetComponent<Enemy1Damage_Es>().Damage(daño);
            animatorHit.SetBool("Hit", true);
            velocidad = 0;
            Destroy(gameObject, 0.1f);
        }
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("hit a Enemigo2");
            collision.gameObject.GetComponent<Enemy2Damage_Es>().Damage(daño);
            animatorHit.SetBool("Hit", true);
            velocidad = 0;
            Destroy(gameObject, 0.1f);
        }
        if (collision.transform.CompareTag("Enemy3"))
        {
            Debug.Log("hit a Enemigo3");
            collision.gameObject.GetComponent<Enemy3Damage_Es>().Damage(daño);
            animatorHit.SetBool("Hit", true);
            velocidad = 0;
            Destroy(gameObject, 0.1f);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            Debug.Log("hit a Enemigo2");
            collision.gameObject.GetComponent<Enemy2Damage_Es>().Damage(daño);
            animatorHit.SetBool("Hit", true);
            velocidad = 0;
            Destroy(gameObject, 0.1f);
        }
        if (collision.transform.CompareTag("Enemy3"))
        {
            Debug.Log("hit a Enemigo3");
            collision.gameObject.GetComponent<Enemy3Damage_Es>().Damage(daño);
            animatorHit.SetBool("Hit", true);
            velocidad = 0;
            Destroy(gameObject, 0.1f);
        }
        if (collision.transform.CompareTag("Enemy1"))
        {
            collision.gameObject.GetComponent<Enemy1Damage_Es>().Damage(daño);
            animatorHit.SetBool("Hit", true);
            velocidad = 0;
            Destroy(gameObject, 0.1f);
        }
    }
}
