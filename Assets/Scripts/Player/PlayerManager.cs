using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
using static UnityEngine.InputSystem.InputAction;
using UnityEditor;
using UnityEngine.Serialization;

public class PlayerManager : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D pHB; // Player HitBox

    [Header("Stats")] [SerializeField] private int playerHealth = 200;
    public int playerDamage = 15;
    [SerializeField] private float stamina = 100f;
    [SerializeField] private float maxSpeed, moveSpeed, cooldown, dashSpeed, updateInterval;
    private float moveDir, sprintSpeed;
    public float jumpForce;

    [Header("UI")] [SerializeField] private Slider healthBar;

    [Header("Interactions")] [SerializeField]
    private Transform wallCheck;

    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private Transform origin;
    [SerializeField] private GameObject gameManager;
    [SerializeField] private GameObject plrProjectile;

    private Collider2D groundCheck;

    public LayerMask groundLayers;
    private Vector3 moveAxis, direction;
    private Vector3 spawnPos;

    private float dashForce, timeSinceLastUpdate;
    private bool canSprint, isSprinting;

    private bool isWallSliding, isWallJumping;
    private readonly float wallSlidingSpeed = 2f;
    private float wallJumpDirection;
    private float wallJumpingCounter;
    private readonly float wallJumpingTime = 0.2f;
    [SerializeField] private float wallJumpingDuration = 0.4f;
    private Vector2 wallJumpPower;

    public GameObject GameOver;

    void Start()
    {
        pHB = GetComponent<Rigidbody2D>();
        healthBar.maxValue = playerHealth;
        UpdatePlayerUI();
        animator = GetComponent<Animator>();
        spawnPos = gameObject.transform.position;
        groundCheck = GetComponent<BoxCollider2D>();
        wallJumpPower = new Vector2(25f, 30f);
        GameOver.SetActive(false);
    }

    void Update()
    {
        if (!isWallJumping)
        {
            if (moveDir > 0)
            {
                Vector3 newScale = gameObject.transform.localScale;
                newScale.x = 1f;
                gameObject.transform.localScale = newScale;
            }

            if (moveDir < 0)
            {
                Vector3 newScale = gameObject.transform.localScale;
                newScale.x = -1f;
                gameObject.transform.localScale = newScale;
            }

            switch (moveDir)
            {
                case < 0 or > 0:
                    animator.SetBool("isWalking", true);
                    break;
                case 0:
                    animator.SetBool("isWalking", false);
                    break;
            }

            //animator.SetFloat("airSpeed", pHB.velocity.y);

            if (pHB.velocity.y > 0.1f)
            {
            }
            else if (pHB.velocity.y < -0.1f)
            {
            }

            if (groundCheck.IsTouchingLayers(groundLayers))
            {
                animator.SetBool("isGrounded", true);
            }
            else if (!groundCheck.IsTouchingLayers(groundLayers))
            {
                animator.SetBool("isGrounded", false);
            }
        }

        animator.SetFloat("yVel", pHB.velocity.y);

        WallSlide();
        WallJump();

        if (!isWallJumping)
        {
            pHB.velocity = new Vector2(moveDir * (moveSpeed + sprintSpeed), pHB.velocity.y);
        }
        
        if (moveDir != 0)
        {
            if (sprintSpeed > 0f)
            {
                animator.SetBool("isRunning", true);
            }
            else
            {
                animator.SetBool("isRunning", false);
            }
        }
    }

    private void FixedUpdate()
    {
        //moveAxis = Vector3.right * moveDir;

        //pHB.AddForce(moveAxis * moveSpeed, ForceMode2D.Force);

        /*
        if (!isWallJumping)
        {
            pHB.velocity = new Vector2(moveDir * (moveSpeed + sprintSpeed), pHB.velocity.y);
        }
        */
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveDir = context.ReadValue<float>();
    }

    public void Dash(InputAction.CallbackContext context)
    {
        
            if (context.performed)
            {
                sprintSpeed = 10f;
            }

            if (context.canceled)
            {
                sprintSpeed = 0f;
                //animator.SetBool("isRunning", false);
            }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (groundCheck.IsTouchingLayers(groundLayers))
        {
            if (context.started)
            {
                pHB.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
                wallJumpingCounter = 0f;
                animator.SetTrigger("Jump");
            }
        }
    }

    public void TakeDamage(int dmgDealt)
    {
        if (playerHealth > 0 && playerHealth != dmgDealt)
        {
            playerHealth -= dmgDealt;
            UpdatePlayerUI();
        }
        else if (playerHealth <= 0 || playerHealth == dmgDealt)
        {
            GameOver.SetActive(true);
            gameObject.transform.position = spawnPos;
            moveDir = 0f;
            playerHealth = 100;
            UpdatePlayerUI();

            Debug.Log("Player died");
        }
    }

    public void UpdatePlayerUI()
    {
        healthBar.value = playerHealth;
        //healthTxt.text = playerHealth + "/" + "200";
    }

    private bool IsWalled()
    {
        // Check if the player is currently touching a wall
        // using a circle overlap check at the position of the wall check object
        // with a radius of 0.2f, and checking against the wallLayer
        return Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer);
    }

    private void WallSlide()
    {
        // Check if the player is currently touching a wall and not touching the ground
        if (IsWalled() && !groundCheck.IsTouchingLayers(groundLayers) && Input.GetAxisRaw("Horizontal") != 0)
        {
            // Enable wall sliding
            isWallSliding = true;
            // Adjust the vertical velocity of the player to a maximum wall sliding speed
            pHB.velocity = new Vector2(pHB.velocity.x, Mathf.Clamp(pHB.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }
        else
        {
            // Disable wall sliding
            isWallSliding = false;
        }
    }

    private void WallJump()
    {
        if (isWallSliding)
        {
            // The player is currently wall sliding, so prepare for a wall jump
            isWallJumping = false;
            // Determine the direction of the wall jump based on the player's local scale
            wallJumpDirection = -gameObject.transform.localScale.x;

            // Reset the wall jumping counter to the maximum duration
            wallJumpingCounter = wallJumpingTime;

            // Cancel any previous invocations of the StopWallJump method
            CancelInvoke(nameof(StopWallJump));
        }
        else
        {
            // Decrement the wall jumping counter over time
            wallJumpingCounter -= Time.deltaTime;
        }

        // Check if the jump button (Space key) is pressed and there is remaining time for wall jumping
        if (Input.GetKeyDown(KeyCode.Space) && wallJumpingCounter > 0f)
        {
            // Activate wall jumping
            isWallJumping = true;
            // Apply a wall jump velocity to the player based on the wallJumpPower vector
            pHB.velocity = new Vector2(wallJumpDirection * wallJumpPower.x, wallJumpPower.y);
            // Reset the wall jumping counter to 0 to prevent additional wall jumps
            wallJumpingCounter = 0f;

            // Check if the player's local scale needs to be adjusted
            if (gameObject.transform.localScale.x != wallJumpDirection)
            {
                // Adjust the local scale of the player based on the wallJumpDirection

                var transformLocalScale = transform.localScale;
                transformLocalScale.x *= -1;
            }
        }
        
        if (wallJumpingCounter <= 0f)
        {
            StopWallJump();
        }
    }

    private void StopWallJump()
    {
        // Disable wall jumping
        isWallJumping = false;
    }
}