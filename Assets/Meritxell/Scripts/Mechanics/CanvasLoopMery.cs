using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasLoopMery : MonoBehaviour
{
    public MoveBackgroundMery mb;

    void Start()
    {
        mb = GetComponent<MoveBackgroundMery>();
        
    }

    void OnTriggerEnter2D(Collider2D other)        
    {


        if (other.CompareTag("EditorOnly"))
        {
            other.GetComponent<MoveBackgroundMery>().ResetPosition();
        }
            
    }
}
