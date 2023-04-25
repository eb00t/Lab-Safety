using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class batteryScript : MonoBehaviour
{
    //public GameObject battery,wall;
    private GameObject player, charger;
    // public GameObject red;
    
    
    public blueSJScript batteryCharge;
    public bool IsCharged, charging;

    public Activation active;
   // public RedSJScript batCheck;
    // Start is called before the first frame update
    void Start()
    { 
        player = GameObject.FindGameObjectWithTag("Player");
       charger = GameObject.FindGameObjectWithTag("Charger");
       IsCharged = false;
       charging = false;
    }

    // Update is called once per frame
    void Update()
    {
       activeBattery();
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
            charging = true;
            gameObject.SetActive(false);
        }
       // if (col.gameObject.CompareTag("Blue") || (col.gameObject.CompareTag("Enemy") && batteryCharge.EnemyisCharged))
       // {
           // batteryCharge.isActivated = true;
           // batteryCharge.EnemyisCharged = false;
        //}
        
       /* if (col.gameObject.CompareTag("Player"))
        {
            //player.transform.position = respawnPoint.position;
            gameObject.transform.parent = player.transform;
        }

        if (col.gameObject.CompareTag("Blue"))
        {
            IsCharged = true;
            
            
        }

        if (IsCharged == true)
        {
            if (col.gameObject.CompareTag("Charger"))
            {
                gameObject.transform.position = charger.transform.position;
                gameObject.transform.parent = charger.transform;
                pickup.enabled = false;
                
            }
        }*/
       
    }

    public void activeBattery()
    {
        
    }
}
