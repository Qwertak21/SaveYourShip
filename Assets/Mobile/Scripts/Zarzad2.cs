using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Zarzad2 : MonoBehaviour
{
    public void PlayUstaw()
    {
        SceneManager.LoadScene(0);
    }

    public void PlayGra�()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitPressed()
    {
        Application.Quit();
    }
}
