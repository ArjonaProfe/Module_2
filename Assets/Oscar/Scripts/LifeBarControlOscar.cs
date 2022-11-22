using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBarControlOscar : MonoBehaviour
{
    public LifeNStatusOscar MyLifeMan;
    public Image Bar, Back;

    //Following
    public bool Follower;
    public Vector3 Adition;

    // Start is called before the first frame update
    void Start()
    {
        transform.SetParent(FindObjectOfType<Canvas>().transform);
    }

    // Update is called once per frame
    void Update()
    {
        if(MyLifeMan != null)
        {
            Bar.fillAmount = (float)(MyLifeMan.Life) / MyLifeMan.MaxLife;
            if (Follower == true)
            {
                transform.position = MyLifeMan.transform.position + Adition;
            }
        }
        else { Destroy(gameObject); }
    }
}
