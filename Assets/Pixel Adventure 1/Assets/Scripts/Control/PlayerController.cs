using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public AudioClip run;
    AudioSource audioSource;
    private Rigidbody2D rig;
    private Animator anim;
    private BoxCollider2D coll;
    public SpriteRenderer sprite;
    public PlayerHealth playerHealth;

    private bool facingRight = true;


    private enum MovementState { idle, running, jumping, falling, hit }
    private float inputX = 0f;
    private bool isMoving = false;



    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    public bool isGrounded = true;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private LayerMask jumpableGround;

    [SerializeField] private AudioSource jumpSFX;
    //[SerializeField] private AudioSource runSFX;


    // Start is called before the first frame update
    public void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();
        playerHealth = GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        HandleJump();
        UpdateAnimationState();
    }



    private void HandleMovement()
    {
        inputX = Input.GetAxisRaw("Horizontal");

        rig.velocity = new Vector2(inputX * speed, rig.velocity.y);
        //if (rig.velocity.x != 0)
        //    isMoving = true;
        //else isMoving = false;
        //if (isMoving)
        //{
        //    if (!runSFX.isPlaying && IsOnGround())
        //    {
        //        runSFX.Play();
        //    }
        //    else
        //    {
        //        runSFX.Stop();
        //    }
        //}


    }


    private void UpdateAnimationState()
    {
        MovementState state = MovementState.idle;
        if (rig.velocity.y > .1f)
        {
            state = MovementState.jumping;
            //flip while jump
            if (Input.GetAxis("Horizontal") != 0f)
            {

                //transform.Rotate(Vector3.up * -180);
                Flip(Input.GetAxis("Horizontal"));

            }


        }
        else if (rig.velocity.y < -.1f)
        {
            state = MovementState.falling;
            //flip while fall
            if (Input.GetAxis("Horizontal") != 0f)
            {

                Flip(Input.GetAxis("Horizontal"));
            }

        }
        else if (Input.GetAxis("Horizontal") != 0f && IsOnGround())
        {
            state = MovementState.running;
            Flip(Input.GetAxis("Horizontal"));
        }


        // else if (Input.GetAxis("Horizontal") == 0f && IsOnGround())
        // {
        //     state = MovementState.idle;
        // }

        anim.SetInteger("state", (int)state);
    }
    //private void CheckOnGround()
    //{
    //    RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector3.down), 10f);

    //    if (hit)
    //    {
    //        Debug.Log("On" + hit.collider.name);
    //    }
    //    else
    //    {
    //        Debug.Log("On air");

    //    }
    //}

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsOnGround())
        {
            rig.velocity = new Vector2(rig.velocity.x, jumpForce);
            isGrounded = false;
            jumpSFX.Play();

        }
    }
    private bool IsOnGround()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    private void Flip(float check)
    {

        Vector3 currentScale = gameObject.transform.localScale;
        if (check > 0)
        {
            currentScale.x = 1;
        }
        else if (check < 0)
        {
            currentScale.x = -1;

        }
        gameObject.transform.localScale = currentScale;
        facingRight = !facingRight;
    }

}
