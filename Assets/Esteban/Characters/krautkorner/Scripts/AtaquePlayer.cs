using System.Collections;
using UnityEngine;

public class AtaquePlayer : MonoBehaviour
{
    private Animator animator;
    private AnimManager_Es animManager_Es;
    private int contadorInstaciasProyectil;
    private bool proyectilInstanciado;


    [Header("Ataque espada")]
    public Transform controllerAttack;
    public bool attack;
    public float radioGolpe;
    public int damage;
    [SerializeField] private float tiempoEntreAtaques;
    [SerializeField] private float tiempoSiguienteAtaques;

    [Header("Ataque disparo")]
    [SerializeField] private Transform controladorDisparo;
    [SerializeField] private GameObject proyectil;
    public bool disparando;
    public bool salidaProyectil;
    [SerializeField] private float tiempoEntreDisparos;
    [SerializeField] private float tiempoSiguienteDisparo;




    void Start()
    {

        animator = GetComponent<Animator>();
        animManager_Es = GetComponent<AnimManager_Es>();
    }

    // Update is called once per frame
    void Update()
    {

        if (tiempoSiguienteAtaques > 0)
        {
            tiempoSiguienteAtaques -= Time.deltaTime;
        }
        if (tiempoSiguienteDisparo > 0)
        {
            tiempoSiguienteDisparo -= Time.deltaTime;
        }
        if (Input.GetButtonDown("Fire1") && tiempoSiguienteAtaques <= 0)
        {
            atacar();
            tiempoSiguienteAtaques = tiempoEntreAtaques;


            //Debug.Log("Entra ataque");
        }
        

        if (Input.GetButtonDown("Fire2") && tiempoSiguienteDisparo <= 0)
        {
            Disparar();
            tiempoSiguienteDisparo = tiempoEntreDisparos;
            proyectilInstanciado = false;
        }
        animator.SetBool("disparo", disparando);

        if (salidaProyectil && tiempoSiguienteDisparo <= 0 && proyectilInstanciado == false)
        {

            Instantiate(proyectil, controladorDisparo.position, controladorDisparo.rotation);
            proyectilInstanciado = true;


        }

    }
    private void FixedUpdate()
    {


    }
    public void atacar()
    {
        attack = true;
        animator.SetBool("transAtaque1", attack);
        //Debug.Log("Ataque es " + attack);
        controllerAttack.Translate(new Vector3(1.2f, 0, 0));
        StartCoroutine(MoveControllerAttack());
        Collider2D coll = Physics2D.OverlapCircle(controllerAttack.position, radioGolpe);

        //Debug.Log(collider.tag);
        //foreach (Collider2D colisionador in objects)
        //{
        if (coll != null)
        {
            Debug.Log(coll.tag);
            if (coll.CompareTag("Destructible_Object"))
            {
                coll.transform.GetComponent<Destructible_Object_Es>().Damage(damage);
            }
            else if (coll.CompareTag("Enemy1"))
            {

                coll.transform.GetComponent<Enemy1Damage_Es>().Damage(damage);
            }
            else if (coll.CompareTag("Enemy"))//Enemy es scorpion
            {
                coll.transform.GetComponent<Enemy2Damage_Es>().Damage(damage);
            }
            else if (coll.CompareTag("Enemy3"))//Enemy es scorpionMini
            {
                coll.transform.GetComponent<Enemy3Damage_Es>().Damage(damage);
            }
        }


        //}
        //Collider2D objetos = Physics2D.OverlapCircleAll(controllerAttack.position, radioGolpe);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(controllerAttack.position, radioGolpe);
    }
    private void Disparar()
    {
        disparando = true;

    }
    IEnumerator MoveControllerAttack()
    {
        
        yield return new WaitForSeconds(0.3f);
        controllerAttack.Translate(new Vector3(-1.2f, 0, 0));
        attack= false;
        animator.SetBool("transAtaque1", attack);
    }



}
