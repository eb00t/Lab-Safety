using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedSJScript : MonoBehaviour
{
    private GameObject player, purp; 
    public GameObject  blue, yellow;
   // public GameObject orange, green;
    public GameObject[] enemy;
    private Transform respawnPoint;

   // private GameObject purp;
        //public bool burn, overCharge, explode, scienceJ;=
     
    public GameObject fireball,boomB;
    //public bool burn, overCharge, explode, scienceJ;=
     
    public RedSJ effects;

    private Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
       // anim1 = GetComponent<Animator>();

       player = GameObject.FindWithTag("Player");
       purp = GameObject.FindWithTag("Purple");
      
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
        
        if (col.gameObject.CompareTag("RedSJ"))
        {
            switch (effects)
            {
                case RedSJ.nothing:
                    // ¯\_(ツ)_/¯
                    break;
                
                case RedSJ.burnable:
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
                
                case  RedSJ.mixSJ:
                    walljump();
                    mixRedSJ();
                    break;
                
                case RedSJ.death:
                    StartCoroutine(death());
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

    IEnumerator death()
    {
        
        if (gameObject.CompareTag("Enemy"))
        {
            foreach (GameObject obj in enemy)
            {
                obj.SetActive(false);
            }
            
            yield return new WaitForSeconds(.01f);
        }
        
        if (gameObject.CompareTag("Player"))
        {
            yield return new WaitForSeconds(1f);
            player.transform.position = respawnPoint.position;
            Debug.Log("im working");
        }
    }
    

    IEnumerator burn()
    {

        fireball.SetActive(true);
        anim.Play("fireA");
        yield return new WaitForSeconds (7f);
        gameObject.SetActive(false);
    }
    

    IEnumerator boom()
    {
        boomB.SetActive(true);
        //anim1.Play("explodeTempA");
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }

    public void walljump()
    {
        purp.SetActive(true);
        gameObject.SetActive(false);
    }

    private void overCharge()
    {
        
    }

    private void mixRedSJ()
    {
        if (gameObject.CompareTag("Blue"))
        {
            Debug.Log("work bih");
            gameObject.SetActive(false);
            purp.SetActive(true);
        }

        if (gameObject.CompareTag("Yellow"))
        {
            blue.SetActive(false);
            yellow.SetActive(false);
        }
    }
}
