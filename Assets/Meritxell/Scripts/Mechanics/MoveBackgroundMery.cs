using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackgroundMery : MonoBehaviour
{

    public RectTransform picture;

    void Start()
    {     
        picture = GetComponent<RectTransform>();               
    }

    void Update()
    {
        picture.anchoredPosition = new Vector2(picture.anchoredPosition.x + 20, 0);

    }
}
