using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float moveSpeed;
    public float moveSpeedStore { get; private set;}
    public float speedMultiplier;

    public float speedIncreaseMilestone;
    public float speedIncreaseMilestoneStore { get; private set; }

    public float speedMilestoneCount;
    public float speedMilestoneCountStore { get; private set; }

    public float jumpForce;

    public float jumpTime;
    private float JumpTimeCounter;

    private bool stoppedJumping;

    private Rigidbody2D myRigidbody;

    public bool grounded;
    public LayerMask whatIsGround;
    public Transform groundCheck;
    public float groundCheckRadius;

    // private Collider2D myCollider;
    private Animator myAnimator;
    public GameManager theGameManager;
    public AudioSource playerJumpSound;

    // Start is called before the first frame update
    void Start() {
        myRigidbody = GetComponent<Rigidbody2D>();
        //myCollider = GetComponent<Collider2D>();
        myAnimator = GetComponent<Animator>();

        JumpTimeCounter = jumpTime;

        speedMilestoneCount = speedIncreaseMilestone;

        moveSpeedStore = moveSpeed;
        speedMilestoneCountStore = speedMilestoneCount;
        speedIncreaseMilestoneStore = speedIncreaseMilestone;

        stoppedJumping = true;
    }

    // Update is called once per frame
    void Update() {
        // Check player is on the platform
        //grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        if(transform.position.x > speedMilestoneCount)
        {
            speedMilestoneCount += speedIncreaseMilestone;

            speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;
            moveSpeed = moveSpeed * speedMultiplier;
        }

        // Player running
        myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);

        // Player attack
        // if(Input.GetMouseButton(0)) {
        //     myAnimator.SetTrigger("attack");
        // }

        // Player jumping
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (grounded) {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
                stoppedJumping = false;
                playerJumpSound.Play();
            }
        }

        // Advanced Jump
        if (Input.GetKey(KeyCode.Space) && !stoppedJumping)
        {
            if(JumpTimeCounter > 0)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
                JumpTimeCounter -= Time.deltaTime;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            JumpTimeCounter = 0;
            stoppedJumping = true;
        }

        if(grounded)
        {
            JumpTimeCounter = jumpTime;
        }

        // Set Animation
        myAnimator.SetFloat("speed", myRigidbody.velocity.x);
        myAnimator.SetBool("grounded", grounded);
    }

    void OnCollisionEnter2D (Collision2D other)
    {
        if(other.gameObject.tag == "killbox")
        {
            theGameManager.RestartGame();
            // moveSpeed = moveSpeedStore;
            // speedMilestoneCount = speedMilestoneCountStore;
            // speedIncreaseMilestone = speedIncreaseMilestoneStore;
        }
    }
}
