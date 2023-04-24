using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dieTemp : MonoBehaviour
{
    private GameObject player;
    private Transform respawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        respawnPoint = GameObject.FindWithTag("Respawn").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            player.transform.position = respawnPoint.position;
        }
    }
}
