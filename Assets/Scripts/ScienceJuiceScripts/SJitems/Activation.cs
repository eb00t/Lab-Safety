using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activation : MonoBehaviour
{
    public bool isDoor;
    
    [SerializeField] public bool isActivated;
    public batteryScript batteryisCharged;
    private GameObject bat;
    public GameObject particleEffects,door;
    private Collider2D chargerCollider;
    public Collider2D SJCollider;
    private Transform Battery;

    // Start is called before the first frame update
    void Start()
    {
        //SJCollider.enabled = false;
       // batteryisCharged = GetComponent<batteryScript>();
        chargerCollider = GetComponent<Collider2D>();
        bat = GameObject.FindGameObjectWithTag("Battery");
        Battery = GameObject.FindGameObjectWithTag("Charger").transform;
        isActivated = false;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
       /* if (isActivated == true)
        {
            particleEffects.SetActive(true);
            
            if (!isDoor)
            {
                Debug.Log("activate");
                chargerCollider.enabled = !chargerCollider.enabled;
                //isActivated = true;
                SJCollider.enabled = true;
            }

            if (isDoor == true)
            {
                Debug.Log("activate");
                chargerCollider.enabled = !chargerCollider.enabled;
                //isActivated = true;
                SJCollider.enabled = false;
                door.SetActive(false);
            }
        }*/
        
        if (!isDoor)
        {

            if (col.gameObject.CompareTag("Battery") && batteryisCharged.IsCharged)
            {
                particleEffects.SetActive(true);
                Debug.Log("activate");
                chargerCollider.enabled = !chargerCollider.enabled;
                //isActivated = true;
                SJCollider.enabled = true;
            }
        }
        
        else if (isDoor)
        {
            if (col.gameObject.CompareTag("Battery") && batteryisCharged.IsCharged)
            {
                particleEffects.SetActive(true);
                Debug.Log("activate");
                chargerCollider.enabled = !chargerCollider.enabled;
                //isActivated = true;
                SJCollider.enabled = false;
                bat.SetActive(false);
                door.SetActive(false);
            }

            else
            {
                isActivated = false;
            }
        }
    }
}
