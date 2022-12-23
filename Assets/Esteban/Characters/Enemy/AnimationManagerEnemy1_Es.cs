using UnityEngine;

public class AnimationManagerEnemy1_Es : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private bool blink;
    [SerializeField] private bool run;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Blink(blink);
        //Run(run);
    }
    public void Blink(bool blk)
    {
        //Debug.Log(blk);
        blink = blk;
        animator.SetBool("Blink", blk);
    }
    public void Muerte()
    {

        animator.SetBool("Muerte", true);
    }
    public void Attack(bool attack)
    {
        animator.SetBool("Attack", attack);
    }
}
