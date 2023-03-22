using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batteryScript : MonoBehaviour
{
    public GameObject player, battery,wall, charger;
    public BoxCollider2D pickup;
    public GameObject red;

    public bool IsCharged;
   // public RedSJScript batCheck;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
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
                wall.SetActive(false);
                red.SetActive(true);
            }
        }

        
    }
}
