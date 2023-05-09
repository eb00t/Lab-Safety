using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerDestroy : MonoBehaviour
{
    public float timer;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        timer = 150f;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        timer--;
        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!gameObject.CompareTag("RedSJ"))
        {
            if (other.CompareTag("Enemy"))
            {
                other.GetComponent<WalkEnemyController>().TakeDamage(player.GetComponent<PlayerManager>().playerDamage);
                Destroy(gameObject);
            }
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Destroy(gameObject);
        }

        if (gameObject.CompareTag("RedSJ") && gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<WalkEnemyController>().StartCoroutine(other.GetComponent<WalkEnemyController>().DamageOverTime());
            Destroy(gameObject);
        }
    }
}
