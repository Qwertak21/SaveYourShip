using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Zarzadzanie : MonoBehaviour
{
    public void PlayNowa()
    {
       SceneManager.LoadScene(2);
    }

    public void Playkontynuj()
    {
        SceneManager.LoadScene(2);
    }

    public void PlayOptions()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitPressed()
    {
        Application.Quit();
    }
}
