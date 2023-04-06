using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redSJBottle : MonoBehaviour
{
   /* public GameObject red;
    public SJBottles bullet;
    public GameObject blue;

    public RedSJScript redScript;
    public string scr;*/
    
    public GameObject purpRed, orangeRed;
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
        if (col.gameObject.CompareTag("BlueSJ"))
        {
            Debug.Log("blue");
            purpRed = Instantiate(purpRed, transform.position, transform.rotation);
            gameObject.SetActive(false);
        }
        
        else if (col.gameObject.CompareTag("YellowSJ"))
        {
            Debug.Log("yellow");
            orangeRed = Instantiate(orangeRed, transform.position, transform.rotation);
            gameObject.SetActive(false);
        }
        else if (col.gameObject.CompareTag("RedSJ"))
        {
            Debug.Log("nothing");
        }
    }
}
