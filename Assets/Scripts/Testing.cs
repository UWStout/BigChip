using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    private EventTimer functionTimer;

    private void Start()
    {
        functionTimer = new EventTimer(TestingAction, 3f);
    }

    private void Update()
    {
        functionTimer.Update();
    }

    private void TestingAction()
    {
        Debug.Log("Testing");
    }

}
