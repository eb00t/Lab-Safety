using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wire : MonoBehaviour
{
    public Rigidbody2D hook;
    public GameObject[] prefWire;

    public int numLinks = 5;
    // Start is called before the first frame update
    void Start()
    {
        GenerateWire();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GenerateWire()
    {
        Rigidbody2D prevBod = hook;
        for (int i = 0; i < numLinks; i++)
        {
            int index = Random.Range(0, prefWire.Length);
            GameObject newSeg = Instantiate(prefWire[index]);
            newSeg.transform.parent = transform;
            newSeg.transform.position = transform.position;
            HingeJoint2D hJ = newSeg.GetComponent<HingeJoint2D>();
            hJ.connectedBody = prevBod;

            prevBod = newSeg.GetComponent<Rigidbody2D>();
        }
    }
}
