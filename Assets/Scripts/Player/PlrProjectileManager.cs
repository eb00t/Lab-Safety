using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlrProjectileManager : MonoBehaviour
{
    public GameObject player;
    private Vector3 mousePos;
    private Rigidbody2D rb2D;
    public float force;

    // contains code from https://www.youtube.com/watch?v=-bkmPm_Besk

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        rb2D.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
           // other.GetComponent<EnemyController>().TakeDamage(player.GetComponent<PlayerManager>().playerDamage);
           // Destroy(gameObject);
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
