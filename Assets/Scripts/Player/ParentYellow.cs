using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentYellow : MonoBehaviour
{
    private GameObject yellowBlock;
    // Start is called before the first frame update
    void Start()
    {
        yellowBlock = GameObject.FindGameObjectWithTag("Yellow");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnCollisionStay (Collision platformCollision)
    {                
        GameObject platformCenter = platformCollision.transform.GetChild(0).gameObject;
        gameObject.transform.parent = platformCenter.transform;    
    }
     
    void OnCollisionExit ()
    {
        gameObject.transform.parent = null;
    }
}
