using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TestingTools : MonoBehaviour
{
    public GameObject escMenu;

    public void Reload()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetKey(KeyCode.R) && Input.GetKeyDown(KeyCode.Minus))
      {
          Time.timeScale = 1;
          SceneManager.LoadScene(SceneManager.GetActiveScene().name);
      }

      if (Input.GetKeyDown(KeyCode.Escape))
      {
            if (escMenu.activeSelf == false)
            {
                escMenu.SetActive(true);
            }
            else if (escMenu.activeSelf == true)
            {
                escMenu.SetActive(false);
            }
      }
    }
}
