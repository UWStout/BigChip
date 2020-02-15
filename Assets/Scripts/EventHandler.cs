using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class EventHandler : MonoBehaviour
{
    public int totalevents = 0;
    public Inventory _inventory;

    //The object is probably going to change for this delegate
    public delegate void EventHasBeenTriggered(object o, GettingEventArgs e);

    public static int GenNumber(int totalevents)
    {
        System.Random random = new System.Random();
        int eventNum = random.Next(1, 9); // The end number is the first digit that doesn't get included in the randomizer, so this is 1 to 8
        totalevents += 1;

        if (totalevents < 11)
        {
            if (totalevents % 2 == 1)
            {
                OnRandEventNum(eventNum);
            }
            else
            {
                OnHouseEventNum(eventNum);
            }
        }
        else if(totalevents == 11)
        {
            // Run end of day sequence
            // totalevents = 0;
        }
        return totalevents;
    }

    public static void OnHouseEventNum(int eventNum)
    {
        System.Random random = new System.Random();
        int index = random.Next(1, 7);


        // ChangeValue(int index, int change)
        if (eventNum == 1)
        {
            //Standard Sale of a single cookie
            //_inventory.ChangeValue(index, 1);
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

//Shows us on the console what is returned
public class EventListner
{
    public void ShowToScreen(object o, GettingEventArgs e)
    {
        Console.WriteLine("Event Triggered. The event is {0}", e.chosenEvent);
    }
}

