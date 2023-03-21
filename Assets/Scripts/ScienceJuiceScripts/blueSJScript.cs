using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blueSJScript : MonoBehaviour
{
    public BlueSJ electric;
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
        if (col.gameObject.CompareTag("Blue"))
        {
            switch (electric)
            {
                case BlueSJ.nothing:
                    break;
                
                case BlueSJ.charge:
                    break;
                
                case BlueSJ.player:
                    break;
                
                case BlueSJ.generator :
                    break;
            }
        }
    }
}
