using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interaction : MonoBehaviour
{
    public UnityEvent interact, playerInteract, scienceInteract; //you can add more of these if necessary
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) //specifically for things that are affected by the player
        {
            playerInteract.Invoke();
        }
        else if (other.gameObject.CompareTag("SJuice")) //specifically for things that are affected by the player
        {
            scienceInteract.Invoke();
        }
        else //for everything else
        {
            interact.Invoke();
        }
    }
}
