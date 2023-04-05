using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine;

public class holdWire : MonoBehaviour
{

    private Rigidbody2D rb;
    public HingeJoint2D hj;

    public GameObject handle;
    public GameObject player;
    private SpringJoint2D springJoint;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        hj = gameObject.GetComponent<HingeJoint2D>();
       // sj = gameObject.GetComponent<SpringJoint2D>();

        /* if (!springJoint)
         {
             GameObject go = new GameObject("Rigidbody2D Dragger");
             Rigidbody2D body = go.AddComponent<Rigidbody2D>() as Rigidbody2D;
             springJoint = go.AddComponent<SpringJoint2D>() as SpringJoint2D;
             //Rigidbody2D body = go.AddComponent ("Rigidbody2D") as Rigidbody2D;
             //springJoint = go.AddComponent ("SpringJoint2D") as SpringJoint2D;
             body.isKinematic = true;
         }*/

    }

    void Start()
    {
        rb.isKinematic = true;
    }
    
    void Update()
    {
        if (Input.GetKey("q"))
        {
            handle.transform.position = hj.transform.position;
            player.transform.parent = hj.transform;
            rb.isKinematic = true;
            //player.transform.parent = handle.transform;
            
        }
        else
        {
            player.transform.parent = null;
            hj.transform.parent = null;
            rb.isKinematic = false;
        }
    }

    public void Attach()
    {
      
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        /*if (col.gameObject.CompareTag("Wire") )
        {
            if (Input.GetKey("q"))
        {
            handle.transform.position = hj.transform.position;
            player.transform.parent = hj.transform;
            rb.isKinematic = true;
            //player.transform.parent = handle.transform;
            
        }
        else
        {
            player.transform.parent = null;
            hj.transform.parent = null;
            rb.isKinematic = false;
        }
        }*/
    }
}
