using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orangeSJScript : MonoBehaviour
{
    public GameObject explosion;
    private Transform respawnPoint;
    public GameObject[] destroyObjects;
    private GameObject breakThis;
    public bool canDestroy;
    
    // Start is called before the first frame update
    void Start()
    {
        breakThis = GameObject.FindWithTag("Destroy");
    }
    

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf)
        {
           // isActive = true;
            StartCoroutine(boom());
            if (canDestroy)
            {
                breakThis.SetActive(false);
            }
        }
    }
    
    IEnumerator boom()
    {
        // anim.SetBool("isElectric", true);
        Debug.Log("exploding");
        explosion.SetActive(true);
        
        
        
        yield return new WaitForSeconds(2f);
        Debug.Log("wait");
        gameObject.SetActive(false);
        
        foreach (GameObject destroyObj in destroyObjects)
        {
            destroyObj.SetActive(false);
        }

    }
}
