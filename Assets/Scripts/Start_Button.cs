using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_Button : MonoBehaviour
{
    public void beginGame(string sceneName)
    {
        Application.LoadLevel(sceneName);
    }
}
