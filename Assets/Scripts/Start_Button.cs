using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_Button : MonoBehaviour
{
    public void beginGame(string sceneName)
    {
        Application.LoadLevel(sceneName);
    }

    public void viewCredits(string sceneName)
    {
        Application.LoadLevel(sceneName);
    }

    public void ReturnToMenu(string sceneName)
    {
        Application.LoadLevel(sceneName);
    }
}
