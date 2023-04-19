using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blueSJScript : MonoBehaviour
{
    private batteryScript charging;
    private GameObject player;
    public GameObject greenBlue, purpBlue;
    private Transform respawnPoint;
    
    public BlueSJ electric;
    
    public bool batteryisCharged, EnemyisCharged;

   //private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        EnemyisCharged = false;
        
        respawnPoint = GameObject.FindWithTag("Respawn").transform;
        player = GameObject.FindGameObjectWithTag("Player");
      //  anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (gameObject.tag == "Blue")
        {
            if (col.gameObject.CompareTag("RedSJ"))
            {
                Debug.Log("red");
                purpBlue = Instantiate(purpBlue, transform.position, transform.rotation);
                gameObject.SetActive(false);
            }
                
            if (col.gameObject.CompareTag("YellowSJ"))
            {
                Debug.Log("yellow");
                greenBlue = Instantiate(greenBlue, transform.position, transform.rotation);
                gameObject.SetActive(false);
            }
            
            if (col.gameObject.CompareTag("Battery"))
            {
                batteryisCharged = true;
            }

            if (col.gameObject.CompareTag("Enemy"))
            {
                EnemyisCharged = true;
            }
            
            if (col.gameObject.CompareTag("Player"))
            {
                player.transform.position = respawnPoint.position;
                Debug.Log("working");
            }
        }
        if (col.gameObject.CompareTag("BlueSJ"))
        {
            switch (electric)
            {
                case BlueSJ.nothing:
                    break;

                case BlueSJ.generator:
                    break;
            }
        }
    }
    IEnumerator Gen()
    {
        return null;
    }
}
