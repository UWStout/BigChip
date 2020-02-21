using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RexMovement : MonoBehaviour
{
    public Rigidbody2D rex;
    public float speed;



    private void Update()
    {
        rex.velocity = rex.velocity.normalized * speed;
    }

    private void Start()
    {
        //rex.velocity = Vector2.(speed, 0);
    }
}
