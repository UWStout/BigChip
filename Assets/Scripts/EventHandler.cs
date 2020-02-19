using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class EventHandler : MonoBehaviour
{
    public int totalevents = 0;
    public static int[] cookies;
    public int bank = 0;
    public Inventory _inventory;

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
    }

    public int GenNumber(int totalevents)
    {
        System.Random random = new System.Random();
        int eventNum = random.Next(1, 101); // The end number is the first digit that doesn't get included in the randomizer, so this is 1 to 100
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

    public void OnHouseEventNum(int eventNum)
    { // WILL NEED TO ADD DIALOGUE AND MONEY TO EVERY SCENARIO
        System.Random random = new System.Random();
        int index = random.Next(1, 8);
        int change;

        if (eventNum >= 1 && eventNum <= 40) //Standard Sale of a single cookie
        {
            change = 1;
            _inventory.ChangeValue(index, change);
        }
        else if (eventNum >= 41 && eventNum <= 65) // Sale of Multiple of One Type of Cookie
        {
            System.Random random2 = new System.Random();
            change = random2.Next(2, 6); // Sale of between 2 and 5 of the same cookie
            _inventory.ChangeValue(index, change);
        }
        else if (eventNum >= 66 && eventNum <= 80) // Sale of Multiple Types of Cookies
        {
            int index2;
            int change2;
            System.Random random2 = new System.Random();
            change = random2.Next(1, 4);
            change2 = random2.Next(1, 4); // Both sales are for 1 to 3 cookies each
            System.Random random3 = new System.Random();
            index2 = random3.Next(1, 7);
            while (index == index2) // Prevents the same type from being sold twice
            {
                index2 = random3.Next(1, 7);
            }
            _inventory.ChangeValue(index, change);
            _inventory.ChangeValue(index2, change2);
        }
        else if (eventNum >= 81 && eventNum <= 90) // Buys one of each type of cookie
        {
            _inventory.ChangeValue(1, 1);
            _inventory.ChangeValue(2, 1);
            _inventory.ChangeValue(3, 1);
            _inventory.ChangeValue(4, 1);
            _inventory.ChangeValue(5, 1);
            _inventory.ChangeValue(6, 1);
        }
        else if (eventNum >= 91 && eventNum <= 100) // You get a tip with your standard delivery
        {
            _inventory.ChangeValue(index, 1);
            _inventory.ChangeValue(7, 7); // $7 dollar tip. Sends to a unique index reference which doesn't affect inventory.
        }

    }


    public void OnRandEventNum(int eventNum)
    {
        System.Random random = new System.Random();
        int index = random.Next(1, 8);
        int change;

        if (eventNum <= 1 && eventNum >= 5) // You find money on the ground
        {
            _inventory.ChangeValue(7, 10);
        }
        else if(eventNum >= 6 && eventNum <= 15) // You find slightly less money on the ground
        {
            _inventory.ChangeValue(7, 5);
        }
        else if (eventNum >= 16 && eventNum <= 25) // Someone steals a box of cookies
        {
            
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

