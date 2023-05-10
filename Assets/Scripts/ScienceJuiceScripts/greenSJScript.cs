using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class greenSJScript : MonoBehaviour
{
    private Vector3 originalSize;
    private void Start()
    {
        originalSize = transform.parent.transform.localScale;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("object detected");
        if (other.CompareTag("YellowSJ")) // quadruple
        {
           // StartCoroutine(ResizeObject(new Vector3(originalSize.x, originalSize.y * 4, originalSize.z)));
        }
        else if (other.CompareTag("RedSJ")) // reset to 0
        { 
            //Debug.Log("Object was red");
           // StartCoroutine(ResizeObject(originalSize));
        }
        else if (other.CompareTag("BlueSJ")) // double
        {
            //StartCoroutine(ResizeObject(new Vector3(originalSize.x, originalSize.y * 2, originalSize.z)));
        }
    }

    private IEnumerator ResizeObject(Vector3 newScale)
    {
        float currentTime = 0.0f;

        while (currentTime < 2f)
        {
            transform.parent.transform.localScale = Vector3.Lerp(transform.parent.transform.localScale, newScale, currentTime / 2f);
            currentTime += Time.deltaTime;
            yield return null;
        }

        transform.parent.transform.localScale = newScale;
    }
}
