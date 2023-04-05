using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadButton : MonoBehaviour
{
    public GameObject[] objectsReset;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        foreach (GameObject obj in objectsReset)
        {
            obj.SetActive(true);
        }
    }
}
