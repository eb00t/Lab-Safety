using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine;

public class holdWire : MonoBehaviour
{

    private Rigidbody2D rb;

    public HingeJoint2D hj;

    private bool attached = false;

    public Transform attachedTo;
    public GameObject player;
    //private GameObject disregard;
    // Start is called before the first frame update

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        hj = gameObject.GetComponent<HingeJoint2D>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(Rigidbody2D wireBone)
    {
        
        if (Input.GetKey("q"))
        {
            wireBone.gameObject.GetComponent<WireSegments>().isPlayerAttached= true;
            hj.connectedBody = wireBone;
            hj.enabled = true;
            attached = true;
            attachedTo = wireBone.gameObject.transform.parent;
            //attachedTo.transform.parent = player.transform;
            // Attach(gameObject.GetComponent<Rigidbody2D>());
        }
        else
        {
            hj.connectedBody.gameObject.GetComponent<WireSegments>().isPlayerAttached = false;
            attached = false;
            hj.enabled = false;
            hj.connectedBody = null;
            //attachedTo.transform.parent = null;
        }
        
    }

   /* public void Attach(Rigidbody2D wireBone)
    {
        wireBone.gameObject.GetComponent<WireSegments>().isPlayerAttached= true;
        hj.connectedBody = wireBone;
        hj.enabled = true;
        attached = true;
        attachedTo = wireBone.gameObject.transform.parent;
    }

    public void Detach()
    {
        hj.connectedBody
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        
        if (Input.GetKey("q"))
        {
            
        }
        else
        {
            Detach();
        }
        
    }*/
}
