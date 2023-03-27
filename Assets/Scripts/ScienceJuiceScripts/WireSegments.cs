using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireSegments : MonoBehaviour
{
    public GameObject connectAbove, connectBelow;

    public bool isPlayerAttached;
    // Start is called before the first frame update
    void Start()
    {
        connectAbove = GetComponent<HingeJoint2D>().connectedBody.gameObject;
        WireSegments aboveSegments = connectAbove.GetComponent<WireSegments>();
        if (aboveSegments != null)
        {
            aboveSegments.connectAbove = gameObject;
            float spriteBottom = connectAbove.GetComponent<SpriteRenderer>().bounds.size.y;
            GetComponent<HingeJoint2D>().connectedAnchor = new Vector2(0, spriteBottom *- 1);
        }
        else
        {
            GetComponent<HingeJoint2D>().connectedAnchor = new Vector2(0, 0);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
