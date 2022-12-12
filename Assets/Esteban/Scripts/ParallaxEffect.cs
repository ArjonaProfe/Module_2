using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    private Transform cameraTransform;
    private Vector3 previousCameraPosition;
    [SerializeField] private float parallaxMulti;
    void Start()
    {
        cameraTransform = Camera.main.transform;
        previousCameraPosition = cameraTransform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float deltaX = (cameraTransform.position.x - previousCameraPosition.x) * parallaxMulti;
        transform.Translate(new Vector3(deltaX, 0, 0));
        previousCameraPosition = cameraTransform.position;
    }
}
