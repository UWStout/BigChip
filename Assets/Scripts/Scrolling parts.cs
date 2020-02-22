using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling_parts : MonoBehaviour
{
    public float parallaxEffect;
    public GameObject cam;
    private float length, startpos;
    private Vector2 screenBounds;


    private void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        screenBounds = cam.screenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
    }

    private void FixedUpdate()
    {
        
        if (screenBounds)
        {

        }
    }

}
