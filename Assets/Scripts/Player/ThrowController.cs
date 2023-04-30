using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowController : MonoBehaviour
{
    private GameObject projectile;
    public GameObject redBallz, fakeSJ;
    public GameObject blueBallz;
    public GameObject yellowBallz;
    
    public float force = 5f;
    Rigidbody2D rb;
    //Rigidbody2D rb2;
    LineRenderer lr;
    [SerializeField] private Transform origin;
    private Vector2 originVec;

    // Start is called before the first frame update
    void Start()
    {
        projectile = fakeSJ;
        rb = projectile.GetComponent<Rigidbody2D>();
        lr = GetComponent<LineRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D col)
        {

            if (col.gameObject.CompareTag("RedStation"))
            {
                //Debug.Log("im workingR");
                projectile = redBallz;
            }
            
            if (col.gameObject.CompareTag("YellowStation"))
            {
                //Debug.Log("im workingY");
                projectile = yellowBallz;
            }

            if (col.gameObject.CompareTag("BlueStation"))
            {
                //Debug.Log("im workingB");
                projectile = blueBallz;
            } 
        }
   void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            originVec = new Vector2(origin.position.x, origin.position.y);
        }

        if (Input.GetMouseButton(0))
        {
            Vector2 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 velocity = (target - originVec) * force;

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
            Vector2 velocity = (target - originVec) * force;
            
            
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
