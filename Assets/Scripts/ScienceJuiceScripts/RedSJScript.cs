using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedSJScript : MonoBehaviour
{
    private GameObject player;
    public GameObject electricExplosion, burnin;
    private Transform respawnPoint;
    public GameObject[] destroyObjects;
    
    public RedSJ effects;
    public SJLink linker;
    
   // private Animator anim;
    public GameObject purpRed, orangeRed;

    void Start()
    {
        //anim = GetComponent<Animator>();
        //electricExplotion = GameObject.Find("/ElectricC");
        respawnPoint = GameObject.FindWithTag("Respawn").transform;
        player = GameObject.FindGameObjectWithTag("Player");
    }
    
    void Update()
    {
        
    }
    
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (gameObject.CompareTag("Red"))
        {
            if (col.gameObject.CompareTag("BlueSJ"))
            {
                linker.blueToPurp = true;
                
                Debug.Log("blue");
                purpRed = Instantiate(purpRed, transform.position, transform.rotation);
                //gameObject.SetActive(false);
                Destroy(gameObject);
            }
            
            else if (col.gameObject.CompareTag("YellowSJ"))
            {
                linker.yellowToOrange = true;
                
                Debug.Log("yellow");
                orangeRed = Instantiate(orangeRed, transform.position, transform.rotation);
                orangeRed.SetActive(true);
                //gameObject.SetActive(false);
                Destroy(gameObject);
            }
            
            else if (col.gameObject.CompareTag("Player"))
            {
                //Debug.Log("im working");
                // yield return new WaitForSeconds(1f);
                player.transform.position = respawnPoint.position;
                Debug.Log("im working");
            }

            switch (effects)
            {
                case RedSJ.explode:
                    if (col.gameObject.tag == "Battery")
                    {
                        StartCoroutine(boom());
                    }
                    
                    //boomBoom();
                    break;
                default: break;
            }
        }
        if (col.gameObject.CompareTag("RedSJ"))
        {
            switch (effects)
            {
                case RedSJ.nothing:
                    // ¯\_(ツ)_/¯
                    break;

                case RedSJ.burnable:
                    if (col.gameObject.CompareTag("Player"))
                    {
                        //Debug.Log("im working");
                        // yield return new WaitForSeconds(1f);
                        player.transform.position = respawnPoint.position;
                        Debug.Log("im working");
                    }

                    StartCoroutine(burn());
                    //burnnin();
                    break;

                case RedSJ.overcharge:
                    overCharge();
                    break;

                case RedSJ.playerRed:
                    player.transform.position = respawnPoint.position;
                    Debug.Log("working");
                    break;
                default: 
                    break;
            }
        }
    }


    IEnumerator burn()
    {
        //anim.SetBool("onFire", true);
        burnin.SetActive(true);
        Debug.Log("on fire");
        yield return new WaitForSeconds (7f);
        gameObject.SetActive(false);
    }
    

    IEnumerator boom()
    {
        
        
       // anim.SetBool("isElectric", true);
       Debug.Log("exploding");
        yield return new WaitForSeconds(2f);
        //gameObject.SetActive(false);
        
        foreach (GameObject destroyObj in destroyObjects)
        {
            destroyObj.SetActive(false);
            electricExplosion.SetActive(true);
        }
    }

    private void overCharge()
    {
        
    }
}
