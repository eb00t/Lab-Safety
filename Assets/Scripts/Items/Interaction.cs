using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interaction : MonoBehaviour
{
    public UnityEvent interact, playerInteract, yellow, red; //you can add more of these if necessary
    public UnityEvent playerExit;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) //specifically for things that are affected by the player
        {
            playerInteract.Invoke();
        }
        
        
        else 
        {
            interact.Invoke();
        }
    }

    /* private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerExit.Invoke();
        }
    }*/
}
