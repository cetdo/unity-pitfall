using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rbPlayer;
    private Animator aniPlayer;
    private SpriteRenderer sprRenPlayer;
    private BoxCollider2D collPlayer;

    private float dirX = 0f;
    private enum MovementState {idle, running, jumping, falling}

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private AudioSource jumpSFX, deathSFX;


    // Start is called before the first frame update
    private void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
        aniPlayer = GetComponent<Animator>();
        sprRenPlayer = GetComponent<SpriteRenderer>();
        collPlayer = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");

        rbPlayer.velocity = new Vector2(dirX * moveSpeed, rbPlayer.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            jumpSFX.Play();
            rbPlayer.velocity = new Vector2(rbPlayer.velocity.x, jumpForce);
        }

        UpdateAnimationState();

    }

    private void UpdateAnimationState()
    {
        MovementState state;
        if (dirX > 0f)
        {
            state = MovementState.running;
            sprRenPlayer.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprRenPlayer.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rbPlayer.velocity.y > .1f) 
        {
            state = MovementState.jumping;
        }
        else if (rbPlayer.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }


        aniPlayer.SetInteger("state",(int) state);
    }
    private bool isGrounded()
    {
        return Physics2D.BoxCast(collPlayer.bounds.center, collPlayer.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

} 
