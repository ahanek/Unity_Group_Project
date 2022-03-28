using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    /*to get player moving, jumping and climbing through notes compiled from online lecture a while ago
     * and will be modified to our game specification
     * https://www.udemy.com/course/unitycourse/
     * professer link: https://www.udemy.com/user/rick-davidson-5/
     */
    //to control the speed of the player
    [SerializeField] public float runSpeed = 10f; 
    [SerializeField] public float jumpSpeed = 5f;
    [SerializeField] public float climbSpeed = 5f;
    
    [SerializeField] private GameObject bullets;
    [SerializeField] private Transform bulletrespawning;
    // for x and y movement
    Vector2 moveInput;
    //for movement
    Rigidbody2D rigidBody;

    //for stopping multijumping
    CapsuleCollider2D capsuleCollider2D;
    //stop player sliding off the ladder
    float gravityScaleAtStart;

    Animator animation;

    [SerializeField] private AudioSource footStepSound;
    [SerializeField] private AudioSource gunShotSound;
    [SerializeField] private AudioSource jumpSound;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animation = GetComponent<Animator>();
        //for stopping multijumping
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        gravityScaleAtStart = rigidBody.gravityScale;
    }
    
    void OnFire(InputValue value)
    {
        gunShotSound.Play();
        Instantiate(bullets, bulletrespawning.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        FlipSprite();
        ClimbLadder();
    }


    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        //for stopping multijumping
        if (!capsuleCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }
        if (value.isPressed)
        {
            jumpSound.Play();
            rigidBody.velocity += new Vector2(0f, jumpSpeed);
        }
    }
    private void Run()
    {
        // move the player in one direction x-Axis right to left
        //rigidBody.velocity.y: keeping the y is it current is don't change it
        Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed, rigidBody.velocity.y);
        //this by itself will make player fly up and down right and left
        //rigidBody.velocity = moveInput;
        rigidBody.velocity = playerVelocity;
        //Mathf.Epsilon: zero
        bool playerhasHorzinonalSpeed = Mathf.Abs(rigidBody.velocity.x) > Mathf.Epsilon;
        animation.SetBool("IsRunning", playerhasHorzinonalSpeed);

    }

    private void FlipSprite()
    {
        bool playerHspeed = Mathf.Abs(rigidBody.velocity.x) > 0.0;
        if (playerHspeed)
        {
            //changing the player directions
            transform.localScale = new Vector2(Mathf.Sign(rigidBody.velocity.x), 1f);
        }

    }

    void ClimbLadder()
    {
        //climb only if touching the ladder if not return empty
        if (!capsuleCollider2D.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            rigidBody.gravityScale = gravityScaleAtStart;
            //for the player not to always climb
            animation.SetBool("isClimbing", false);
            return;
        }
        // move the player in one direction x-Axis up to down
        //rigidBody.velocity.y: keeping the y is it current is don't change it
        Vector2 climbingSpeed = new Vector2(rigidBody.velocity.x, moveInput.y *climbSpeed);
        //this by itself will make player fly up and down right and left
        //rigidBody.velocity = moveInput;
        rigidBody.velocity = climbingSpeed;
        //preventing sliding off the ladder
        rigidBody.gravityScale = 0f;
        bool playerClimbingSpeed = Mathf.Abs(rigidBody.velocity.y) >0.0;
        //change climb latter animation
        animation.SetBool("isClimbing", playerClimbingSpeed);
    }

    private void Footstep()
    {
        footStepSound.Play();
    }
}
