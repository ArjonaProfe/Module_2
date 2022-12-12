using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimManager_Es : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer spriteRenderer;
    private PlayerMovement_Es playerMovement;
    private AtaquePlayer ataquePlayer;
    


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerMovement = GetComponent<PlayerMovement_Es>();
        ataquePlayer = GetComponent<AtaquePlayer>();

    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("transicionCorrer", Mathf.Abs(playerMovement.XMovement));
    }
    private void FixedUpdate()
    {
        anim.SetBool("enSuelo", playerMovement.EnSuelo);
    }
    public void SaltarAnimacion()
    {
        anim.SetBool("enSuelo", playerMovement.EnSuelo);
    }
    public void Muerte()
    {
        anim.SetBool("muerto", true);
        StartCoroutine(DestroyAndReborn());

    }
    IEnumerator DestroyAndReborn()

    {        
        yield return new WaitForSeconds(1.2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //gameObject.SetActive(false);
        //GameObject startPoint = GameObject.Find("CheckPointStart");
        ////transform.position = Vector2.MoveTowards(transform.position, startPoint.transform.position,
        ////    0.1f * Time.deltaTime);
        //
        //gameObject.transform.Translate(startPoint.transform.position - transform.position, Space.World);
        ////aDebug.Log("startPosition " + startPoint.transform.position);
        ////aDebug.Log("transform.position " + transform.position);
        ////aDebug.Log("RESTA " + (startPoint.transform.position - transform.position));
        //gameObject.SetActive(true);
        //playerMovement.Vida = 100f;
        
        

    }

}



