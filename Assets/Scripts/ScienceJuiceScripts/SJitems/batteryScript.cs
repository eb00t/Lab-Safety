using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class batteryScript : MonoBehaviour
{
    //public GameObject battery,wall;
    private GameObject player;
    public GameObject charger;
    // public GameObject red;
    public GameObject lowBat;
    
    public blueSJScript batteryCharge;
    public bool IsCharged, charging;

    private ActivationOpen active;

    private Activation activated;
   // public RedSJScript batCheck;
  
    void Start()
    { 
        player = GameObject.FindGameObjectWithTag("Player");
       //charger = GameObject.FindGameObjectWithTag("Charger");
       IsCharged = false;
       activated = charger.GetComponent<Activation>();
      // active = charger.g
       //charging = false;
    }

    // Update is called once per frame
    void Update()
    {
       activeBattery();
       if (IsCharged)
       {
           lowBat.SetActive(false);
       }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Blue"))
        {
            IsCharged = true;
        }
        
        
        if (col.gameObject.CompareTag("Charger") && IsCharged)
        {
            gameObject.transform.position = charger.transform.position;
            gameObject.transform.parent = charger.transform;
            gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            IsCharged = false;
            //charging = true;
            activated.isActivated = true;
            gameObject.SetActive(false);
        }

        if (IsCharged)
        {
            foreach(Transform t in transform) 
            {
                t.gameObject.SetActive(true);
                return;
            }

            
        }

    }

    public void activeBattery()
    {
    }
}
