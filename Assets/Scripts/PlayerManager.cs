using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
using static UnityEngine.InputSystem.InputAction;
using UnityEditor;

public class PlayerManager : MonoBehaviour
{
    public GameObject player;
    public GameObject gameManager;
    public GameObject plrProjectile;
    public Animator dmgIndc;

   private Animator animator;
    private Rigidbody2D pHB; // Player HitBox
    public SpriteRenderer pM, shovel; // Player Character
    public Collider2D groundCheck;

    public Transform origin;

    public int playerHealth = 200;
    public int playerDamage = 15;

    public float maxSpeed, moveSpeed, jumpForce, moveDir, cooldown, dashSpeed, updateInterval, sprintSpeed;
    private float dashForce, timeSinceLastUpdate;
    private bool canSprint, isSprinting;
    //public bool canDig, canAttack;

    //public Slider healthBar;
    //public TextMeshProUGUI healthTxt;

    public LayerMask groundLayers;
    private Vector3 moveAxis, direction;
    public Vector3 spawnPos;

    private float stamina = 100f;

    private bool isWallSliding,isWallJumping;
    private float wallSlidingSpeed = 2f;
    private float wallJumpDirection, walljumpingCounter;
    private float wallJumpingTime = 0f;
    private float walljumpingDuration = 0.4f;
    private Vector2 wallJumpPower = new Vector2(8f, 16f);
    [SerializeField] private Transform wallCheak;
    [SerializeField] private LayerMask wallLayer;

    void Start()
    {
        pHB = GetComponent<Rigidbody2D>();
        playerHealth = 200;
        UpdatePlayerUI();
        animator = GetComponent<Animator>();
        spawnPos = player.transform.position;
    }

    void Update()
    {
        if (moveDir > 0)
        {
            //pM.flipX = true;
            //shovel.flipX = false;
            Vector3 newScale = player.transform.localScale;
           newScale.x = 0.5f;
           player.transform.localScale = newScale;
        }
        if (moveDir < 0)
        {
            //pM.flipX = false;
            Vector3 newScale = player.transform.localScale;
            newScale.x = -0.5f;
            player.transform.localScale = newScale;
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
            //animator.SetBool("onTheGround", true);
        }
        else if (!groundCheck.IsTouchingLayers(groundLayers))
        {
            //animator.SetBool("onTheGround", false);
        }
        WallSlide();
    }

    private void FixedUpdate()
    {
        //moveAxis = Vector3.right * moveDir;

        //pHB.AddForce(moveAxis * moveSpeed, ForceMode2D.Force);
        pHB.velocity = new Vector2(moveDir * (moveSpeed + sprintSpeed), pHB.velocity.y);
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
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (groundCheck.IsTouchingLayers(groundLayers))
        {
            if (context.started)
            {
                pHB.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            }
        }
    }

    public void TakeDamage(int dmgDealt)
    {
        if (playerHealth > 0 && playerHealth != dmgDealt)
        {
            playerHealth -= dmgDealt;
            dmgIndc.enabled = true;

            dmgIndc.SetTrigger("Hit");
            UpdatePlayerUI();
        }
        else if (playerHealth <= 0 || playerHealth == dmgDealt)
        {
            player.transform.position = spawnPos;
            moveDir = 0f;
            playerHealth = 100;
            UpdatePlayerUI();

            Debug.Log("Player died");
        }
    }

    public void UpdatePlayerUI()
    {
        //healthBar.value = playerHealth;
        //healthTxt.text = playerHealth + "/" + "200";
    }

    private bool isWalled()
    {
        return Physics2D.OverlapCircle(wallCheak.position, 0.2f, wallLayer);
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
            wallJumpDirection = -transform.localScale.x;
            walljumpingCounter = wallJumpingTime;
        }
        else
        {
            walljumpingCounter -= Time.deltaTime;
        }

       // if (Jump() && walljumpingCounter >0f)
       // {
            
       // }
    }
}