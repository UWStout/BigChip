using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class EventHandler : MonoBehaviour
{
    public int totalevents = 0;
    public int[] cookies;
    public GameObject OptionA; // Make the sale button
    public GameObject OptionB; // Refuse the sale button

    //The object is probably going to change for this delegate
    public delegate void EventHasBeenTriggered(object o, GettingEventArgs e);

    void Start()
    {
        //initialize the array with a size
        //unity doesnt like to change size
        //we dont need to so we should be ok
        int[] cookies = new int[6];

        //currently hardcode to set values into the array
        cookies.SetValue(8, 0);
        cookies.SetValue(6, 1);
        cookies.SetValue(7, 2);
        cookies.SetValue(5, 3);
        cookies.SetValue(3, 4);
        cookies.SetValue(9, 5);

        OptionA.SetActive(false);
        OptionB.SetActive(false);
    }

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
<<<<<<< HEAD
            //_inventory.ChangeValue(index, 1);
=======
            
>>>>>>> 2b034673e17d5bc44409bae2f3ddf925e68e5bd6
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

    void ChangeValue(int index, int change)
    {
        if (index == 1)
        {
            if (change < 0)
            {
                cookies[0] -= change;
            }
            else if (change > 0)
            {
                cookies[0] += change;
            }

        }
        else if (index == 2)
        {
            if (change < 0)
            {
                cookies[1] -= change;
            }
            else if (change > 0)
            {
                cookies[1] += change;
            }
        }
        else if (index == 3)
        {
            if (change < 0)
            {
                cookies[2] -= change;
            }
            else if (change > 0)
            {
                cookies[2] += change;
            }
        }
        else if (index == 4)
        {
            if (change < 0)
            {
                cookies[3] -= change;
            }
            else if (change > 0)
            {
                cookies[3] += change;
            }
        }
        else if (index == 5)
        {
            if (change < 0)
            {
                cookies[4] -= change;
            }
            else if (change > 0)
            {
                cookies[4] += change;
            }
        }
        else if (index == 6)
        {
            if (change < 0)
            {
                cookies[5] -= change;
            }
            else if (change > 0)
            {
                cookies[5] += change;
            }
        }
        else
        {
            print("Number is not in reference to inventory list");
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

