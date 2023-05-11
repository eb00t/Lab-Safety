using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class purpleSJScript : MonoBehaviour
{
    public SJLink purplink;
    //public GameObject
    
    public GameObject purpToblue, purpToRed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (gameObject.tag == "Purple")
        {
            
        }
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("BlackSJ") && purplink.blueToGreen == true)
        {
            Debug.Log("back");
            // originalSJ.SetActive(true);
            Destroy(gameObject);
            purpToblue = Instantiate(purpToblue, transform.position, transform.rotation);
            //gameObject.SetActive(false);
        }
        
        else if (col.gameObject.CompareTag("BlackSJ")  && purplink.blueToPurp == true)
        {
            Debug.Log("back");
            //originalSJ.SetActive(true);
            Destroy(gameObject);
            purpToRed = Instantiate(purpToRed, transform.position, transform.rotation);
            //gameObject.SetActive(false);
        }
    }
}
