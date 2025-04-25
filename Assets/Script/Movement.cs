using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;
    public Transform Groundcheck;
    public Transform WallCheck;
    public LayerMask Groundmask;
    public LayerMask WallMask;

    public float moveSpeed = 35f;
    public float jumpForce = 30f;
    public float wallSlideSpeed = 5f;
    public float wallJumpForceX = 25f;
    public float wallJumpForceY = 30f;

    private bool isTouchingWall;
    private bool isGrounded;
    private bool isWallSliding;
    private int wallDirX;

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        float Xspeed = 0;
        float Yspeed = rb.velocity.y;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(0, -1), 0.3f, Groundmask);
        RaycastHit2D wallHitRight = Physics2D.Raycast(WallCheck.position, Vector2.right, 0.3f, WallMask);
        RaycastHit2D wallHitLeft = Physics2D.Raycast(WallCheck.position, Vector2.left, 0.3f, WallMask);

        isTouchingWall = wallHitRight || wallHitLeft;
        wallDirX = wallHitRight ? 1 : wallHitLeft ? -1 : 0;

        if (Input.GetKey(KeyCode.D))
        {
            Xspeed = moveSpeed;
            WallCheck.localPosition = new Vector3(0.5f, WallCheck.localPosition.y, 0);
            //facing right!
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Xspeed = -moveSpeed;
            WallCheck.localPosition = new Vector3(0.5f, WallCheck.localPosition.y, 0);
            //facing left!
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (isTouchingWall && !isGrounded && rb.velocity.y < 0)
        {
            isWallSliding = true;
            Yspeed = wallSlideSpeed;
        }
        else
        {
            isWallSliding = false;
        }

        if (Input.GetKey(KeyCode.W))
        {
            if(hit == true)
            {
                Yspeed = jumpForce;
            }   
            else if (isWallSliding)
            {
                Xspeed = -wallDirX * wallJumpForceX;
                Yspeed = wallJumpForceY;
            }

        }

        rb.velocity = new Vector2(Xspeed, Yspeed);

    }
}
