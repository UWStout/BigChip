using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTimer
{
    private int numOfEvents = 0;
    private Action action;
    private float timer;
    private bool isFinished;
    

    public EventTimer(Action action, float timer)
    {
        this.action = action;
        this.timer = timer;
    }

    public void Update()
    {
        if (!isFinished)
        {
            timer -= Time.deltaTime;
                if (timer < 0)
                {
                    //trigger action
                    action();
                    EndEvents(numOfEvents);
                }
        }
        
    }

    private void EndEvents(int numOfEvents)
    {
        numOfEvents++;
        isFinished = true;
    }

}
