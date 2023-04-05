using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
using static UnityEngine.InputSystem.InputAction;
using UnityEditor;

public class PlayerManager : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D pHB; // Player HitBox

    [Header("Stats")]
    [SerializeField] private int playerHealth = 200;
    public int playerDamage = 15;
    [SerializeField] private float stamina = 100f;
    [SerializeField] private float maxSpeed, moveSpeed, cooldown, dashSpeed, updateInterval;
    private float moveDir, sprintSpeed;
    public float jumpForce;

    [Header("UI")]
    [SerializeField] private Slider healthBar;

    [Header("Interactions")]
    [SerializeField] private Transform wallCheck;
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

    private bool isWallSliding,isWallJumping;
    private float wallSlidingSpeed = 2f;
    private float wallJumpDirection;
    private float walljumpingCounter;
    private float wallJumpingTime = 0.2f;
    private float walljumpingDuration = 0.4f;
    private Vector2 wallJumpPower = new Vector2(25f, 30f);

    void Start()
    {
        pHB = GetComponent<Rigidbody2D>();
        healthBar.maxValue = playerHealth;
        UpdatePlayerUI();
        animator = GetComponent<Animator>();
        spawnPos = gameObject.transform.position;
        groundCheck = GetComponent<BoxCollider2D>();
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
    
            if (moveDir < 0 || moveDir > 0)
            {
                animator.SetBool("isWalking", true);
            }
            else if (moveDir == 0)
            {
               animator.SetBool("isWalking", false);
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
        wallJump();
    }

    private void FixedUpdate()
    {
        //moveAxis = Vector3.right * moveDir;

        //pHB.AddForce(moveAxis * moveSpeed, ForceMode2D.Force);
        
        if (!isWallJumping)
        {
            pHB.velocity = new Vector2(moveDir * (moveSpeed + sprintSpeed), pHB.velocity.y);
        }
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
            animator.SetBool("isRunning", true);
        }
        if (context.canceled)
        {
            sprintSpeed = 0f;
            animator.SetBool("isRunning", false);
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (groundCheck.IsTouchingLayers(groundLayers))
        {
            if (context.started)
            {
                pHB.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
                walljumpingCounter = 0f;
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

    private bool isWalled()
    {
        return Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer);
    }

    private void WallSlide()
    {
        if (isWalled() && !groundCheck.IsTouchingLayers(groundLayers))
        {
            isWallSliding = true;
            pHB.velocity = new Vector2(pHB.velocity.x, Mathf.Clamp(pHB.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }
        else
        {
            isWallSliding = false;
        }
    }

    private void wallJump()
    {
        if (isWallSliding)
        {
            isWallJumping = false;
            wallJumpDirection = -gameObject.transform.localScale.x;;
            walljumpingCounter = wallJumpingTime;
            
            CancelInvoke(nameof(StopWallJump));
        }
        else
        {
            walljumpingCounter -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) && walljumpingCounter > 0f)
        {
            //Debug.Log("wall is activate working");
            isWallJumping = true;
            pHB.velocity = new Vector2(wallJumpDirection * wallJumpPower.x, wallJumpPower.y);
            walljumpingCounter = 0f;

            if (gameObject.transform.localScale.x != wallJumpDirection)
            {
               // Debug.Log("wall is working");
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
            }
            
            Invoke(nameof(StopWallJump), walljumpingDuration);
        }
    }

    private void StopWallJump()
    {
        isWallJumping = false;
    }
}