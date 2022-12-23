using UnityEngine;

public class Enemy1Tracing_Es : MonoBehaviour
{
    //[SerializeField] private Transform transformPlayer;
    private AIBasic_Es aIBasic_Es;
    private AnimationManagerEnemy1_Es animator;

    void Start()
    {
        aIBasic_Es = transform.parent.GetComponent<AIBasic_Es>();
        animator = transform.parent.GetComponent<AnimationManagerEnemy1_Es>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Speed_ " + aIBasic_Es.Speed_);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Player detectado");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Player detectado");
        //Debug.Log(collision.tag);
        if (collision.transform.CompareTag("Player"))
        {
           //Debug.Log("Player detectado");
           //Debug.Log(aIBasic_Es.Speed_);
            aIBasic_Es.Speed_ = 3f;
            aIBasic_Es.Detectado = true;
            animator.Attack(true);

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            //Debug.Log("Player detectado");
            //Debug.Log(aIBasic_Es.Speed_);
            aIBasic_Es.Speed_ = 2f;
            aIBasic_Es.Detectado = false;
            animator.Attack(false);
        }
    }

}
