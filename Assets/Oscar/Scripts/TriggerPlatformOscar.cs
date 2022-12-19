using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlatformOscar : MonoBehaviour
{
    public Vector3 Pos1, Pos2;
    public int ThingsOn;
    public float Goal, Timer, Percent, PosDist;
    public Animator Anim;

    // Start is called before the first frame update
    void Start()
    {
        ThingsOn = 0;
        PosDist = Vector3.Distance(Pos1, Pos2);
    }

    // Update is called once per frame
    void Update()
    {
        Percent = Vector3.Distance(transform.position, Pos2) / PosDist;

        if (ThingsOn > 0 && transform.position != Pos2)
        {
            Timer += Time.deltaTime / Goal;
            transform.position = Vector3.Lerp(Pos1, Pos2, Timer);
            Anim.SetBool("Trigger", true);
        }
        else if (ThingsOn == 0 && transform.position != Pos1)
        {
            Timer -= Time.deltaTime / Goal;
            transform.position = Vector3.Lerp(Pos2, Pos1, 1 - Timer);
            Anim.SetBool("Trigger", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.SetParent(transform);
        print(collision.name);
        ThingsOn += 1;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.transform.parent == transform)
        {
            collision.transform.SetParent(null);
        }
        ThingsOn -= 1;
    }
}
