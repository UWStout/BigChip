using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScroll : MonoBehaviour
{
    float scrollSpeed = -5f;
    Vector2 startPos;
    void Start()
    {
        startPos = transform.position;
    }

    // Once we get art assets, we can alter this how we need
    void Update()
    {
        float newPos = Mathf.Repeat(Time.time * scrollSpeed, 20);
        transform.position = startPos + Vector2.right * newPos;
    }
}
