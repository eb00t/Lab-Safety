using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowSJScript : MonoBehaviour
{
    private Vector3 scaleIncrease = new Vector3(3,3,3);
    private GameObject selectedObject;
    
    private YellowSJ growing;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
       // selectedObject = col.gameObject;
        
        if (gameObject.tag == "Yellow")
        {
            if (col.gameObject.CompareTag("YellowSJ"))
            {
                Debug.Log("grow bitch");
                //selectedObject = col.gameObject;
                gameObject.transform.localScale += scaleIncrease;
                if (col.transform.localScale.y < 3f || col.transform.localScale.y > 5f)
                {
                    scaleIncrease = new Vector3(0, 0, 0);
                }
            }
            
        }

        if (col.gameObject.CompareTag("YellowSJ"))
        {
            
        }
    }
}
