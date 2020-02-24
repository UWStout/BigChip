using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rex;
    bool moving;
    public Animator anim;


    private void Start()
    {
        rex = GetComponent<Rigidbody2D>();
        rex.velocity = new Vector3(speed, 0, 0);
        moving = true;
    }

    public void IsHeMoving()
    {
        //Debug.Log("function check");
        if (moving == true)
        {
           // Debug.Log("Should stop moving");
            rex.velocity = new Vector3(0, 0, 0);
            moving = false;
            anim.StartPlayback();
        }
        else
        {
           // Debug.Log("Should start moving");
            rex.velocity = new Vector3(speed, 0, 0);
            moving = true;
            anim.StopPlayback();
        }
    }
}
