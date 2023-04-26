using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activation : MonoBehaviour
{
    //public GameObject activatedObject;
    [SerializeField] private bool isActivated;
    private batteryScript batteryisCharged;
    private GameObject bat;
    private Collider2D chargerCollider;
    public Collider2D SJCollider;
    private Transform Battery;

    // Start is called before the first frame update
    void Start()
    {
        SJCollider.enabled = false;
        chargerCollider = GetComponent<Collider2D>();
        bat = GameObject.FindGameObjectWithTag("Charger");
        Battery = GameObject.FindGameObjectWithTag("Charger").transform;
        isActivated = false;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Battery") && Battery.transform.IsChildOf(transform))
        {
            Debug.Log("activate");
            chargerCollider.enabled = !chargerCollider.enabled;
            isActivated = true;
            SJCollider.enabled = true;
        }

        /*if (isActivated)
        {
            SJCollider.enabled = true;
        }*/

      
        
       /* if (col.gameObject.CompareTag("Battery"))
        {
            isActivated = true;
        }*/
    }
}
