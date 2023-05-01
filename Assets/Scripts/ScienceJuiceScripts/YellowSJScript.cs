using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowSJScript : MonoBehaviour
{
    public Vector3 scaleIncrease = new Vector3(3,3,3);
   // private Vector3 scaleDecrease = new Vector3(0,0,0);
    private GameObject selectedObject;
    
    private YellowSJ growing;

    private bool isgrowing;
    // Start is called before the first frame update
    void Start()
    {
        isgrowing = false;
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
                isgrowing = true;
                //selectedObject = col.gameObject;
                StartCoroutine(growShrink());
            }
        }

        if (col.gameObject.CompareTag("YellowSJ"))
        {
            switch (growing)
            {
                case YellowSJ.nothing:
                    break;
                case YellowSJ.growEnemy:
                    break;
                case YellowSJ.itemsGrow:
                    break; 
            }
        }
    }

    IEnumerator growShrink()
    {
        while (isgrowing == true)
        {
            yield return new WaitForSeconds (3f);
            scaleIncrease = new Vector3(10,15.75f,1);
            Debug.Log("grow bitches");
            gameObject.transform.localScale = scaleIncrease;

            yield return new WaitForSeconds (3f);
            Debug.Log("loop");
            scaleIncrease = new Vector3(10,2, 1);
            gameObject.transform.localScale = scaleIncrease;
           
        }
    
    }
}
