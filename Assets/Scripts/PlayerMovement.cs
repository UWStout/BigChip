using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rex;
    bool moving = true;

    private void Start()
    {
        rex = GetComponent<Rigidbody2D>();
        rex.velocity = new Vector3(speed, 0, 0);
    }

    //private void Update()
    //{
    //    rex.velocity = new Vector3(speed, 0, 0);
    //}

    public void IsHeMoving()
    { 
        if (moving == true)
        {
            rex.velocity = new Vector3(0, 0, 0);
            moving = false;
        }
        else
        {
            rex.velocity = new Vector3(speed, 0, 0);
            moving = true;
        }
    }
}
