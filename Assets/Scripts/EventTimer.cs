using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTimer : MonoBehaviour
{
    public PlayerChoice button1;
    

    [Range(3, 15)]
    public float waitTime;

    public Coroutine currentCoroutine = null;

    //Should be called again after the event stops
    public IEnumerator TriggerEvent()
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime); //wait for time then continue
           // Debug.Log("An Event would trigger now");
            button1.Choice.transform.gameObject.SetActive(true);
            button1.Other.transform.gameObject.SetActive(true);

            StopEvent(); 
            button1.TestingAction();
            //function call for trigger
        }
    }


    //time set needs to be longer than the trigger
    public void StopEvent()
    {
        //Debug.Log("New events have stopped");
        StopCoroutine(currentCoroutine);
    }

    void Start()
    {
        currentCoroutine = StartCoroutine(TriggerEvent());
    }

}