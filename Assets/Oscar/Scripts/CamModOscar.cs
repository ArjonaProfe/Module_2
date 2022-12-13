using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamModOscar : MonoBehaviour
{
    public float Size;
    public Vector3 Pos;
    public Transform CustomPos;
    public List<GameObject> ToAppear;
    //WARNING: don't put two of these too near eachother. If the player touches two at the same time there will be a problem
}
