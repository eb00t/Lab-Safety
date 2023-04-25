using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activation : MonoBehaviour
{
    //public GameObject activatedObject;
    public bool isActivated;
    public batteryScript batteryisCharged;
    private Collider2D chargerCollider;
    public Collider2D SJCollider;

    // Start is called before the first frame update
    void Start()
    {
        SJCollider.enabled = false;
        chargerCollider = GetComponent<Collider2D>();
        isActivated = false;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Battery") && col.transform.IsChildOf(transform))
        {
            Debug.Log("activate");
            chargerCollider.enabled = !chargerCollider.enabled;
            isActivated = true;
        }

        if (isActivated)
        {
            SJCollider.enabled = true;
        }

        if (batteryisCharged.IsCharged)
        {
            
        }
        
       /* if (col.gameObject.CompareTag("Battery"))
        {
            isActivated = true;
        }*/
    }
}
