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
    public float wallStickTime = 1.5f;
    private float wallStickCounter;
    public float wallJumpForceX = 25f;
    public float wallJumpForceY = 30f;
    
    private bool isTouchingWall;
    private bool isGrounded;
    private bool isWallSliding;
    private int wallDirX;
    private bool canWallJump;
    private bool hasWallJumped;
    //bool isMovingRight = Input.GetKey(KeyCode.D);
    //bool isMovingLeft = Input.GetKey(KeyCode.A);

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

        if (!isWallSliding && wallStickCounter > 0)
        {
            if (Input.GetKey(KeyCode.D))
            {
                Xspeed = moveSpeed;


                rb.velocity = new Vector2(Xspeed, 0);
                WallCheck.localPosition = new Vector3(0.0828f, WallCheck.localPosition.y, 0);
                //facing right!
                transform.localScale = new Vector3(25, 25, 1);
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            Xspeed = -moveSpeed;

            rb.velocity = new Vector2(Xspeed, 0);

            WallCheck.localPosition = new Vector3(0.0828f, WallCheck.localPosition.y, 0);
            //facing left!
            transform.localScale = new Vector3(-25, 25, 1);
        }

        if (isTouchingWall && !hit && rb.velocity.y < 0)
        {

            if (wallStickCounter > 0)
            {
                wallStickCounter -= Time.deltaTime;
                Yspeed = 0; // stick (no slide)
                isWallSliding = false;
            }
            else
            {
                isWallSliding = true;
                Yspeed = -wallSlideSpeed; // slide after stick timer
            }

            canWallJump = true;

        }
        else
        {
            isWallSliding = false;
            canWallJump = false;
            wallStickCounter = wallStickTime; //reset when off wall or grounded
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            if(hit == true)
            {
                Yspeed = jumpForce;
            }   
            else if (isTouchingWall && !isGrounded)
            {
                Xspeed = -wallDirX * wallJumpForceX;
                Yspeed = wallJumpForceY;

                
                wallStickCounter = wallStickTime; //reset timer aftrer jumping
                 //prevent multiple wall jumps in the same stick
            }

        }

        rb.velocity = new Vector2(Xspeed, Yspeed);

    }
}
