using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerDestroy : MonoBehaviour
{
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 150f;
    }

    // Update is called once per frame
    void Update()
    {
        timer--;
        if (timer<= 0)
        {
            Destroy(gameObject);
        }
    }
}
