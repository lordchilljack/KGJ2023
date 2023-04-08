using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ApplicationCalls : MonoBehaviour
{
    public bool Webopened = false;
    public int screenNumber;

    public void LoadScreen(int screenNumber)
    {
        SceneManager.LoadScene(screenNumber);
    }

    public void TurnOffGame()
    {
        Application.Quit();
    }
    public void OpenFacebook()
    {
        if (!Webopened)
        {
            Application.OpenURL("https://www.facebook.com/TryHarderOkay");
            Webopened = true;
        }
    }
    public void OpenDova()
    {
        if (!Webopened)
        {
            Application.OpenURL("https://dova-s.jp/");
            Webopened = true;
        }
    }
}
