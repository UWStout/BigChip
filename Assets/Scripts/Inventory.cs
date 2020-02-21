using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int[] cookies = new int[6];
    public int[] price = new int[6];
    public string[] cookie_name = new string[6]{"chocolate chip", "s'mores", "sea salt caramel", "double chocolate chip", "snickerdoodle", "sugar" };
    public int bank;
    public int totalevents = 0;

    public Text bankText;
    private int currentBank;

    public Text cookie1;
    public Text cookie2;
    public Text cookie3;
    public Text cookie4;
    public Text cookie5;
    public Text cookie6;


    void Start()
    {
        cookie1.text = cookies[0].ToString();
        cookie2.text = cookies[1].ToString();
        cookie3.text = cookies[2].ToString();
        cookie4.text = cookies[3].ToString();
        cookie5.text = cookies[4].ToString();
        cookie6.text = cookies[5].ToString();
        bankText.text = "Money: $" + bank.ToString();
    }

    public void GenNumber()
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
        else if (totalevents == 11)
        {
            // Run end of day sequence
            // totalevents = 0;
        }
    }

    public void OnRandEventNum(int eventNum)
    {
        System.Random random = new System.Random();
        int index = random.Next(1, 8);
<<<<<<< HEAD
        
=======
        //int change;
>>>>>>> 4156e83d4ea9e1cdfafa735825a73518b761f827

        if (eventNum <= 1 && eventNum >= 5) // You find money on the ground
        {
            ChangeValue(7, 10);
        }
        else if (eventNum >= 6 && eventNum <= 15) // You find slightly less money on the ground
        {
            ChangeValue(7, 5);
        }
        else if (eventNum >= 16 && eventNum <= 25) // Someone steals a box of cookies
        {
            ChangeValue(8, -1);
        }
        else if (eventNum >= 26 && eventNum <= 40) // Another delivery person is done for the day and gives you some extra stock
        {
            System.Random how_many = new System.Random();
            System.Random how_much = new System.Random();
            int extra_stock = how_many.Next(1, 4); // Maximum three types of inventory gained
            if (extra_stock == 1)
            {
                int change = how_much.Next(1, 5);
                ChangeValue(9, change);
            }
            else if (extra_stock == 2)
            {
                int change = how_much.Next(1, 5);
                int change2 = how_much.Next(1, 5);
                ChangeValue(9, change);
                ChangeValue(9, change2);
            }
            else if (extra_stock == 3)
            {

            }
        }
        else if (eventNum == 5)
        {
            //Event 2
        }

    }

    public void OnHouseEventNum(int eventNum)
    { // WILL NEED TO ADD DIALOGUE TO EVERY SCENARIO
        System.Random random = new System.Random();
        int index = random.Next(1, 9);
        int change;
        bool choice;
        // Make a long if statement for which text will display here







        choice = PlayerChoice.ReturnUserInput();


        if (eventNum >= 1 && eventNum <= 40) //Standard Sale of a single cookie
        {
           change = 1;
           ChangeValue(index, -change);
        }
        else if (eventNum >= 41 && eventNum <= 65) // Sale of Multiple of One Type of Cookie
        {
            System.Random random2 = new System.Random();
            change = random2.Next(2, 6); // Sale of between 2 and 5 of the same cookie
            ChangeValue(index, -change);
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
            ChangeValue(index, -change);
            ChangeValue(index2, -change2);
        }
        else if (eventNum >= 81 && eventNum <= 90) // Buys one of each type of cookie
        {
            ChangeValue(1, -1);
            ChangeValue(2, -1);
            ChangeValue(3, -1);
            ChangeValue(4, -1);
            ChangeValue(5, -1);
            ChangeValue(6, -1);
        }
        else if (eventNum >= 91 && eventNum <= 100) // You get a tip with your standard delivery
        {
            ChangeValue(index, -1);
            ChangeValue(7, 7); // $7 dollar tip. Sends to a unique index reference which doesn't affect inventory.
        }

    }

    // IMPORTANT NOTE 
    // The index goes from 1-6 in reference to the 6 elements in our list
    // However, index can go higher during the case of a special event
    // index primarily controls which element in the array is going to alter
    // change can be positive or negative which will subtract or add the amount
    // error msg will print if an index is too high
    public void ChangeValue(int index, int change)
    {
        if (index >= 1 && index <= 6) // General sale events
        {
            if (change < 0)
            {
                if (cookies[index - 1] + change < 0) // cookies[x] is positive, change is negative, positive plus negative means subtraction
                {
                    change = cookies[index - 1]; // Changes change to be whatever the inventory total is, making change a positive number
                    cookies[index - 1] = 0; // This should always equal zero
                }
                else
                {
                    cookies[index - 1] += change; // Change here is still negative, adding it to the inventory will result in a smaller number, but will still be greater than zero
                    change = -(change); // Sets the change to positive to work with the money update
                }
                bank = price[index - 1] * change;
                UpdateBank();
            }
            else if (change >= 0)
            {
                cookies[index - 1] += change; // Gaining inventory. Just add it on. No call to bank.
            }
            UpdateInventory();
        }
        else if (index == 7) // Change in money only event
        {
            bank = change;
            UpdateBank();
        }
        else if (index == 8) // Stolen / Lost inventory event
        {
            System.Random random = new System.Random();
            int stolen = random.Next(1, 7);
            while (stolen != 0)
            {
                if (cookies[stolen - 1] <= 0)
                {
                    stolen = random.Next(1, 7);
                }
                else
                {
                    break;
                }
            }
            cookies[stolen - 1] += change;
            UpdateInventory();
        }
        else if (index == 9) // Gained inventory, but money was not involved
        {

        }
        else
        {
            print("Number is not in reference to inventory list");
        }
    }

    public void UpdateBank() // Updates the total money the player has after any event involving money
    {
        currentBank += bank;
        bankText.text = "Money: $" + currentBank.ToString();
    }

    public void UpdateInventory() // Updates the total inventory the player has after any event involving inventory
    {
        cookie1.text = cookies[0].ToString();
        cookie2.text = cookies[1].ToString();
        cookie3.text = cookies[2].ToString();
        cookie4.text = cookies[3].ToString();
        cookie5.text = cookies[4].ToString();
        cookie6.text = cookies[5].ToString();
    }
}
