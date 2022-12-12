using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera1Follow : MonoBehaviour
{
    
    public Transform player;
    public Vector3 offset;
    public float cameraSpeed = 10f;
    void Start()
    {
        
        //offset = new Vector3(0.75f, 0.75f, -1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LateUpdate()
    {

        transform.position = player.position + offset;
    }
}
