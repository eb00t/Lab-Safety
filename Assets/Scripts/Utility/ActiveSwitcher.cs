using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSwitcher : MonoBehaviour
{
    public void DisableThisObject()
    {
        gameObject.SetActive(false);
    }
    
   public void EnableThisObject()
    {
        gameObject.SetActive(true);
    }
    
   public void SwitchThisObject()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
