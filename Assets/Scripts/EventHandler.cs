using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventHandler : MonoBehaviour
{
     

    //The object is probably going to change for this delegate
    public delegate void EventHasBeenTriggered(object o, GettingEventArgs e);

    public static void OnHouseEventNum(int eventNum)
    {
        if (eventNum == 1)
        {
            //Standard Sale of a single cookie

        }
        else if (eventNum == 2)
        {
            //Event 2
        }
        else if (eventNum == 3)
        {
            //Event 3
        }
        else if (eventNum == 4)
        {
            //Event 4
        }
        else if (eventNum == 5)
        {
            //Event 5
        }
        else if (eventNum == 6)
        {
            //Event 6
        }

    }


    public static void OnRandEventNum(int eventNum)
    {
        if (eventNum == 1)
        {
            //Event 1
        }else if(eventNum == 2)
        {
            //Event 2
        }
        else if (eventNum == 3)
        {
            //Event 2
        }
        else if (eventNum == 4)
        {
            //Event 2
        }
        else if (eventNum == 5)
        {
            //Event 2
        }

    }


    public static int GenNumber()
    {
        int eventNum = 0;
        //int Random.Range(0, 10);

        return eventNum;
    }
}



//Shows us on the console what is returned
public class EventListner
{
    public void ShowToScreen(object o, GettingEventArgs e)
    {
        Console.WriteLine("Event Triggered. The event is {0}", e.chosenEvent);
    }
}

//gives a reference to the sending object
//i.e. gives the delegate up top a reference to the event
public class GettingEventArgs : EventArgs
{
    public readonly int chosenEvent;

    public GettingEventArgs(int num)
    {
        chosenEvent = num;
    }
}
