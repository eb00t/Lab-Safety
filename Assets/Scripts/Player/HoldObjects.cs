using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HoldObjects : MonoBehaviour
{
    [SerializeField] private Transform grabPoint, rayPoint;
    [SerializeField] private float rayDistance;

    public batteryScript ischarging;
    private GameObject grabbedObject;
    private int layerIndex;
    private bool letGo;
    void Start()
    {
        letGo = false;
        layerIndex = LayerMask.NameToLayer("Object");
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(rayPoint.position, transform.forward, rayDistance);
        
        if (hitInfo.collider != null && hitInfo.collider.gameObject.layer == layerIndex)
        {
            if (Keyboard.current.eKey.wasPressedThisFrame && grabbedObject == null && ischarging.charging == false)
            {
                grabbedObject = hitInfo.collider.gameObject;
                grabbedObject.GetComponent<Rigidbody2D>().isKinematic = true;
                grabbedObject.transform.position = grabPoint.position;
                grabbedObject.transform.SetParent(transform);
               
                letGo = true;
                //Debug.Log("pick up");
            }
            
        }
        else if (Keyboard.current.eKey.wasPressedThisFrame && letGo == true)
        {
            grabbedObject.GetComponent<Rigidbody2D>().isKinematic = false;
            grabbedObject.transform.SetParent(null);
            grabbedObject = null;
               
            letGo = false;
            //Debug.Log("let gooooo");
        }
        
        Debug.DrawRay(rayPoint.position, transform.right * rayDistance);
    }
}
