using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orangeSJScript : MonoBehaviour
{
    public GameObject explosion;
    private Transform respawnPoint;
    public GameObject[] destroyObjects;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf)
        {
            StartCoroutine(boom());
        }
    }
    
    IEnumerator boom()
    {
        // anim.SetBool("isElectric", true);
        Debug.Log("exploding");
        explosion.SetActive(true);
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
        
        foreach (GameObject destroyObj in destroyObjects)
        {
            destroyObj.SetActive(false);
        }
    }
}
