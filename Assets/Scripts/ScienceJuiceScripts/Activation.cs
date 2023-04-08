using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activation : MonoBehaviour
{

    public bool isActivated;

    
    // Start is called before the first frame update
    void Start()
    {
        isActivated = false;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
       /* if (col.gameObject.CompareTag("Battery"))
        {
            isActivated = true;
        }*/
    }
}
