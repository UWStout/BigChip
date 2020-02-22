using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rex;

    private void Start()
    {
        rex = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rex.velocity = new Vector3(speed, 0, 0);
    }
}
