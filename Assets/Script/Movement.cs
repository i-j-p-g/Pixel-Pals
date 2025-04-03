using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;
    public Transform groundcheck;
    public LayerMask Groundmask;

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        float Xspeed = 0;
        float Yspeed = rb.velocity.y;

        RaycastHit2D hit = Physics2D.Raycast(groundcheck.position, new Vector2(0, -1), 0.3f, Groundmask);

        if (Input.GetKey(KeyCode.D))
        {
            Xspeed = 25;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Xspeed = -25;
        }
        if (Input.GetKey(KeyCode.W))
        {
            Yspeed = 10;
        }

        rb.velocity = new Vector2(Xspeed, Yspeed);

    }
}
