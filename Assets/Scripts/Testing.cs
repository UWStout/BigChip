using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    //private bool decided;

    private void Start()
    {
        EventTimer.Create(TestingAction, 25f);
    }

    private void TestingAction()
    {
        PlayerChoice.isActive = true;
        PlayerChoice.Choice.transform.gameObject.SetActive(true);
        PlayerChoice.Other.transform.gameObject.SetActive(true);
        //call event function
    }

}
