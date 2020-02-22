using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EventTimer
{
    public static EventTimer Create(Action action, float timer)
    {
        EventTimer EventTimer = new EventTimer(action, timer);

        GameObject gameObject = new GameObject("EventTimer", typeof(MonoHook));
        gameObject.GetComponent<MonoHook>().onUpdate = EventTimer.Update;

        return EventTimer;
    }

    private class MonoHook : MonoBehaviour {
        public Action onUpdate;
        private void Update()
        {
            if (onUpdate != null) onUpdate();

            
        }

    }
    private int numOfEvents = 0;
    private Action action;
    private float timer;
    private float pauseTimer = 0f;
    private bool isFinished;

    private EventTimer(Action action, float timer)
    {
        this.action = action;
        this.timer = timer;
        isFinished = false;
    }

    public void Update()
    {
        pauseTimer += Time.deltaTime;
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
        if (numOfEvents == 9)
        {
            isFinished = true;
        }
        numOfEvents++;
    }

}
