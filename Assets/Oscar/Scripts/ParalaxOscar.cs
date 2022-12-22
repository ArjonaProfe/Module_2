using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxOscar : MonoBehaviour
{
    public Vector2 StartPos, Dimentions;
    public GameObject Camera;
    public float ParEffect;

    // Start is called before the first frame update
    void Start()
    {
        StartPos = transform.position;
        Dimentions = GetComponent<SpriteRenderer>().bounds.size;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 distance = Camera.transform.position * ParEffect;
        transform.position = StartPos + distance;
    }
}
