using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class pauseScript : MonoBehaviour
{
    public UnityEvent gamePaused;
    public UnityEvent gameResumed;
    private bool isPaused;

    private GameObject zahMenu;
    // Start is called before the first frame update
    void Start()
    {
        zahMenu = GameObject.FindWithTag("Menu");
        zahMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isPaused = !isPaused;
            if (isPaused)
            {
                zahMenu.SetActive(true);
                Time.timeScale = 0;
                gamePaused.Invoke();
                Debug.Log("paused");
            }
            else
            {
                zahMenu.SetActive(false);
                Time.timeScale = 1;
                gameResumed.Invoke();
                Debug.Log("resume");
            }
        }
    }
    
    
}
