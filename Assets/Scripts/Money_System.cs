using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Money_System : MonoBehaviour
{
    private int bank;
    private GameplayManager gameplayObject;

    private void Awake()
    {
        gameplayObject = GameObject.FindObjectOfType<GameplayManager>();
    }
}
