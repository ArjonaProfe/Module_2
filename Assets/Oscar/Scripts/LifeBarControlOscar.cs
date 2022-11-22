using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBarControlOscar : MonoBehaviour
{
    public LifeNStatusOscar MyLifeMan;
    public Image Bar, Back;

    //Following

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(MyLifeMan != null) { Bar.fillAmount = (float)(MyLifeMan.Life) / MyLifeMan.MaxLife; }
    }
}
