using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blueSJScript : MonoBehaviour
{
    private batteryScript charging;
    private GameObject player;
    //public GameObject[] enemy;
    public Transform respawnPoint;
    
    public BlueSJ electric;
    
    public bool batteryisCharged, EnemyisCharged;

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        EnemyisCharged = false;
        
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("BlueSJ"))
        {
            switch (electric)
            {
                case BlueSJ.nothing:
                    break;
                
                case BlueSJ.player:
                    break;
                
                case BlueSJ.generator:
                    break;
                
                case BlueSJ.charge:
                    Debug.Log("charge");
                    break;
                
                case BlueSJ.enemyCharge:
                    //might delete
                    break;
            }

            if (col.gameObject.CompareTag("Battery"))
            {
                batteryisCharged = true;
            }

            if (col.gameObject.CompareTag("Enemy"))
            {
                EnemyisCharged = true;
            }
            
            
        }
    }

    IEnumerator charger()
    {
        
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
