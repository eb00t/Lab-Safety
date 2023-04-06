using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadButton : MonoBehaviour
{
    public GameObject[] objectsResetActive;
    public GameObject[] objectsResetDeactive;
    
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
        foreach (GameObject obj in objectsResetActive)
        {
            obj.SetActive(true);
        }
        
        foreach (GameObject objD in objectsResetDeactive)
        {
            objD.SetActive(false);
        }
    }
}
