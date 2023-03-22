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
}