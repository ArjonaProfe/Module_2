using UnityEngine;

public class PlatformMoving : MonoBehaviour
{


    [SerializeField] private float speed = 0f;
    private float waitTime;
    [SerializeField] private float startWaitTime = 2f;
    private int i = 0;
    private Vector2 actualPosition;
    [SerializeField] private Transform[] moveSpots;

    void Start()
    {
        waitTime = startWaitTime;
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, moveSpots[i].transform.position,
            speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, moveSpots[i].transform.position) < 0.1f)
        {
            if (waitTime <= 0)
            {
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
                waitTime -= Time.deltaTime;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)

    {
        if (collision.collider.CompareTag("Player"))
        {
            speed = 2f;
            collision.collider.transform.SetParent(transform);
        }

       
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        
            collision.collider.transform.SetParent(null);

        
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
       

            collision.collider.transform.SetParent(transform);
        
    }

}
