using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitGizmoOscar : MonoBehaviour
{
    public List<GameObject> ActObj;
    public Animator Anim;

    public void Reaction()
    {
        for (int i = 0; i < ActObj.Count; i++)
        {
            if(ActObj[i].transform.childCount > 0)
            {
                ActObj[i].transform.GetChild(0).SetParent(null);
            }
            ActObj[i].SetActive(!ActObj[i].activeSelf);
        }
        Anim.SetBool("State", !Anim.GetBool("State"));
    }
}
