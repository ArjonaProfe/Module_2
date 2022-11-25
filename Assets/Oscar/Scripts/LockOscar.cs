using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockOscar : MonoBehaviour
{
    public GrabItemOscar.GrabType MyType;
    public GameObject ParSys;

    public void OpenSalami()
    {
        Instantiate(ParSys, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
