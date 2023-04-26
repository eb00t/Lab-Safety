using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationOpen : MonoBehaviour
{
    public bool isActive;
    public batteryScript batteryisCharged;
    public GameObject particleEffects, door;
    private Collider2D chargerCollider;
    
    private Transform Battery;
    
    void Start()
    {
        chargerCollider = GetComponent<Collider2D>();
        Battery = GameObject.FindGameObjectWithTag("Charger").transform;
        isActive = false;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Battery") && batteryisCharged.IsCharged)//Battery.transform.IsChildOf(transform))
        {
            Debug.Log("activate");
            chargerCollider.enabled = !chargerCollider.enabled;
            isActive = true;
        }

        if (isActive)
        {
            particleEffects.SetActive(true);
            door.SetActive(false);
        }
    }
}
