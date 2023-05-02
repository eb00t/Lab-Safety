using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class pauseScript : MonoBehaviour
{
    public UnityEvent gamePaused;
    public UnityEvent gameResumed;
    private bool isPaused;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isPaused = !isPaused;
            if (isPaused)
            {
                Time.timeScale = 0;
                gamePaused.Invoke();
                Debug.Log("paused");
            }
            else
            {
                Time.timeScale = 1;
                gameResumed.Invoke();
                Debug.Log("resume");
            }
        }
    }
    
    
}
