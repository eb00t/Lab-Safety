using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blueSJScript : MonoBehaviour
{
    private batteryScript charging;
    public GameObject player;
    public GameObject[] enemy;
    public Transform respawnPoint;

    private bool batIsCharged = false;
    //private bool isCharged = false;
    public BlueSJ electric;

    
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
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
                
                case BlueSJ.player:
                    break;
                
                case BlueSJ.generator :
                    break;
            }

            if (col.gameObject.CompareTag("Battery"))
            {
                switch (electric)
                {
                    case BlueSJ.charge:
                        StartCoroutine("charger");
                        break;
                }
            }
            
            
        }

        if (charging)
        {
            
        }
    }

    IEnumerator charger()
    {
        batIsCharged = true;

        if (batIsCharged == true)
        {
            
        }
        return null;
    }

    IEnumerator charged()
    {
        return null;
    }
    
    IEnumerator shock()
    {
        if (gameObject.CompareTag("Player"))
        {
            yield return new WaitForSeconds(1f);
            player.transform.position = respawnPoint.position;
            Debug.Log("im working");
        }
    }
    IEnumerator Gen()
    {
        return null;
    }
    
    //private void activate
}
