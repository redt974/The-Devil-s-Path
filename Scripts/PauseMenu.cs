using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public Timer time;
    public void Resume()


    {
        time.Settimer();

        SceneManager.LoadScene(2);

    }

    public void Backto()
    {
        SceneManager.LoadScene(0);

    }
    public void ExitGame()
    {
       

        Application.Quit();

    }

}















