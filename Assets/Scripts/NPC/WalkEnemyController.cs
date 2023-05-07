using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WalkEnemyController : MonoBehaviour
{
    [Header("Attack Parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private int damage;

    [Header("Collider Parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header("Player Layer")]
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;

    [Header("Defense Parameters")]
    public int enemyHealth;

    private float timer;
    private float nextHitTime;
    [SerializeField] private float damageTime = 3f;
    [SerializeField] private float damageDelay = .5f;
    [SerializeField] private int dotDamage = 2;
    private bool isDOT;

    //References
    private Animator anim;
    private PlayerManager playerManager;
    private WalkEnemyPatrol enemyPatrol;
    private Slider healthBar;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<WalkEnemyPatrol>();
        healthBar = GetComponentInChildren<Slider>();
    }

    private void Start()
    {
        healthBar.maxValue = enemyHealth;
        healthBar.value = enemyHealth;
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        //Attack only when player in sight?
        if (PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown)
            {
                anim.SetTrigger("attack");
                cooldownTimer = 0;
            }
        }

        if (enemyPatrol != null)
        {
            enemyPatrol.enabled = !PlayerInSight();
        }

        if (isDOT)
        {
            if (Time.time > nextHitTime)
            {
                nextHitTime = Time.time + damageDelay;
                TakeDamage(dotDamage);
            } 
        }
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit =
            Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);

        if (hit.collider != null)
        {
            playerManager = hit.transform.GetComponent<PlayerManager>();
        }

        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    private void DamagePlayer()
    {
        Debug.Log("Attacking");
        if (PlayerInSight())
        {
            Debug.Log("IN sight");
            playerManager.TakeDamage(damage);
        }
    }

    public void TakeDamage(int dmgDealt)
    {
        if (enemyHealth - dmgDealt > 0)
        {
            enemyHealth -= dmgDealt;
            healthBar.value = enemyHealth;
        }
        else if (enemyHealth - dmgDealt <= 0)
        {
            enemyHealth = 0;
            healthBar.value = enemyHealth;
            gameObject.SetActive(false);
        }
    }

    public IEnumerator DamageOverTime()
    {
        isDOT = true;
        nextHitTime = Time.time;
        yield return new WaitForSeconds(damageTime);
        isDOT = false;
    }
}