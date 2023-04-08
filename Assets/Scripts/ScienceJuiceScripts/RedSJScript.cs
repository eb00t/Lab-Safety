using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedSJScript : MonoBehaviour
{
    private GameObject player;
   // public GameObject[] enemy;
    public Transform respawnPoint;
    
    public RedSJ effects;
    
    private Animator anim;
    public GameObject purpRed, orangeRed;

    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    
    void Update()
    {
        
    }
    
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        /*
        if (!col.gameObject.CompareTag("Enemy") || !col.gameObject.CompareTag("Battery") || !col.gameObject.CompareTag("Generator") || !col.gameObject.CompareTag("burns"))
        {
            mixingSJ();
            
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
        }*/
        

        if (col.gameObject.CompareTag("Player"))
        {
            //Debug.Log("im working");
           // yield return new WaitForSeconds(1f);
            player.transform.position = respawnPoint.position;
            Debug.Log("im working");
        }

        else if (col.gameObject.CompareTag("RedSJ"))
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
                
                case RedSJ.explode:
                    StartCoroutine(boom());
                   //boomBoom();
                    break;
                case RedSJ.playerRed:
                    player.transform.position = respawnPoint.position;
                    Debug.Log("im working");
                    break;
                
                case RedSJ.mixSJ:
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
                    break;

                default: break;
            }
        }

    }


    IEnumerator burn()
    {
        anim.SetBool("onFire", true);
        yield return new WaitForSeconds (7f);
        gameObject.SetActive(false);
    }
    

    IEnumerator boom()
    {
        anim.SetBool("isElectric", true);
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }

    private void overCharge()
    {
        
    }

    private void mixingSJ()
    {
        
    }
}
