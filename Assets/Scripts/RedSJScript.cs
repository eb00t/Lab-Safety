using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedSJScript : MonoBehaviour
{
    public GameObject player;
    public Transform respawnPoint;
    //public bool burn, overCharge, explode, scienceJ;

    public RedSJ effects;

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
        if (col.gameObject.CompareTag("Wire"))
        {
            
        }
        
        if (col.gameObject.CompareTag("Red"))
        {
            switch (effects)
            {
                case RedSJ.nothing:
                    break;
                
                case RedSJ.burnable:
                    Destroy(gameObject, 2.0f);
                    break;
                
                case RedSJ.overcharge:
                    break;
                
                case RedSJ.explode:
                    //temp explosion
                    Destroy(gameObject, 2f);
                    break;
                
                case  RedSJ.mixSJ:
                    break;
                
                case RedSJ.playerRed:
                    player.transform.position = respawnPoint.position;
                    Debug.Log("im working");
                    break;
                default: break;
            }
        }
    }

   /* private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Red"))
        {
            switch (effects) 
            {
                case RedSJ.nothing:
                    break;
                case RedSJ.burnable: 
                    Destroy(col.gameObject); 
                    break;
                case RedSJ.death:
                    if (col.gameObject.CompareTag("Player"))
                    {
                        player.transform.position = respawnPoint.position;
                        //death();
                        //Destroy(gameObject);
                        Console.WriteLine("im working");
                    }
                    break;
                default: 
                    break;
            }
        }
    }*/

    private void death()
    {
        player.transform.position = respawnPoint.position;
    }

}
