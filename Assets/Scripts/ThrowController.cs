using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowController : MonoBehaviour
{
    public GameObject projectile;
    private GameObject redStation;
    public float force = 5f;
    Rigidbody2D rb;
    LineRenderer lr;
    Vector2 origin;

    // Start is called before the first frame update
    void Start()
    {
        rb = projectile.GetComponent<Rigidbody2D>();
        lr = GetComponent<LineRenderer>();
    }
   /* private void OnTriggerEnter2D(Collider2D col)
        {
            if (gameObject.CompareTag("Player") && gameObject.CompareTag("RedStation"))
            {
                projectile = GameObject.FindWithTag("Red") ;
            }

            else
            {
                projectile = GameObject.FindWithTag("BlueSJ");
            }
        }*/
   void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            origin = (Vector2)transform.position;
        }

        if (Input.GetMouseButton(0))
        {
            Vector2 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 velocity = (target - origin) * force;

            Vector2[] trajectory = Plot(rb, (Vector2)transform.position, velocity, 500);
            lr.positionCount = trajectory.Length;
            Vector3[] positions = new Vector3[trajectory.Length];

            for (int i = 0; i < trajectory.Length; i++)
            {
                positions[i] = trajectory[i];
            }

            lr.SetPositions(positions);
        }

        if (Input.GetMouseButtonUp(0))
        {
            Vector2 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 velocity = (target - origin) * force;
            
            
            GameObject newProj = Instantiate(projectile, transform.position, projectile.transform.rotation);
            newProj.GetComponent<Rigidbody2D>().velocity = velocity;

            lr.positionCount = 0;
        }
    }
    
    

    public Vector2[] Plot(Rigidbody2D rigidbody, Vector2 pos, Vector2 vel, int steps)
    {
        Vector2[] results = new Vector2[steps];

        float timestep = Time.fixedDeltaTime / Physics2D.velocityIterations;
        Vector2 gravityAccel = Physics2D.gravity * rb.gravityScale * timestep * timestep;
        float drag = 1f - timestep * rigidbody.drag;
        Vector2 moveStep = vel * timestep;

        for (int i = 0; i < steps; i++)
        {
            moveStep += gravityAccel;
            moveStep *= drag;
            pos += moveStep;
            results[i] = pos;
        }

        return results;
    }

    
}
