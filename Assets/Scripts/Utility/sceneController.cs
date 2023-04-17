using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneController : MonoBehaviour
{
    /*
    public void playGame()
    {
        SceneManager.LoadScene(1);
    }
    */

    public void quitGame()
    {
        Application.Quit();
        Debug.Log("QUIT GAME!");
    }

    public void replayGame()
    {
        SceneManager.LoadScene(0);
    }

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("LOADED NEXT LEVEL!");
    }

    public void level1()
    {
        SceneManager.LoadScene(1);
        Debug.Log("LOADED LEVEL 1!");
    }

    public void level2()
    {
        Debug.Log("LOADED LEVEL 2!");
    }

    public void level3()
    {
        Debug.Log("LOADED LEVEL 3!");
    }

}
