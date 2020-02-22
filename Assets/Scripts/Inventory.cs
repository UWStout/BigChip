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

    public Text displayMessage;


    void Start()
    {
        cookie1.text = cookies[0].ToString();
        cookie2.text = cookies[1].ToString();
        cookie3.text = cookies[2].ToString();
        cookie4.text = cookies[3].ToString();
        cookie5.text = cookies[4].ToString();
        cookie6.text = cookies[5].ToString();
        bankText.text = "Money: $" + bank.ToString();
        displayMessage.text = "";
    }

    public void GenNumber()
    {
        System.Random random = new System.Random();
        int eventNum = random.Next(1, 101); // The end number is the first digit that doesn't get included in the randomizer, so this is 1 to 100
        totalevents += 1;

        if (totalevents % 2 == 1)
        {
            OnRandEventNum(eventNum);
        }
        else
        {
            OnHouseEventNum(eventNum);
        }
    }

    public void OnRandEventNum(int eventNum)
    {
        System.Random random = new System.Random();

        int index = random.Next(1, 7);
        bool choice;

        if (eventNum <= 1 && eventNum >= 5) // You find money on the ground
        {
            displayMessage.text = "Hey! Money! Take it?";
            choice = PlayerChoice.ReturnUserInput();
            if (choice == true)
            {
                ChangeValue(7, 10);
            }
            displayMessage.text = " ";
        }
        else if (eventNum >= 6 && eventNum <= 15) // You find slightly less money on the ground
        {
            displayMessage.text = "Hey! Money! Take it?";
            choice = PlayerChoice.ReturnUserInput();
            if (choice == true)
            {
                ChangeValue(7, 5);
            }
            displayMessage.text = " ";
        }
        else if (eventNum >= 16 && eventNum <= 25) // Someone steals a cookie
        {
            displayMessage.text = "Hey, kid. Those are some tasty looking cookies you got there. Why don't you hand one over...".ToString();
            choice = PlayerChoice.ReturnUserInput();
            if (choice == true)
            {
                ChangeValue(8, -1);
            }
            else if (choice == false) // You should've clicked confirm. Now you lose cookie and money
            {
                ChangeValue(8, -1);
                ChangeValue(7, -10);
            }
            displayMessage.text = " ";
        }
        else if (eventNum >= 26 && eventNum <= 40) // Gain inventory from another deliveryman
        {
            displayMessage.text = "Hello there, fellow delivery dino! I'm done for the day, so do you want to take my unsold cookies?".ToString();
            choice = PlayerChoice.ReturnUserInput();
            if (choice == true)
            {
                System.Random how_many = new System.Random();
                System.Random which_kind = new System.Random();
                int extra_stock = how_many.Next(1, 4); // Maximum three types of inventory gained
                if (extra_stock == 1)
                {
                    int change = which_kind.Next(1, 7);
                    ChangeValue(9, change);
                }
                else if (extra_stock == 2)
                {
                    int change = which_kind.Next(1, 7);
                    int change2 = which_kind.Next(1, 7);
                    while (change != 0)
                    {
                        if (change == change2)
                        {
                            change2 = which_kind.Next(1, 7);
                        }
                        else
                        {
                            break;
                        }
                    }
                    ChangeValue(9, change);
                    ChangeValue(9, change2);
                }
                else if (extra_stock == 3)
                {
                    int change = which_kind.Next(1, 7);
                    int change2 = which_kind.Next(1, 7);
                    int change3 = which_kind.Next(1, 7);
                    while (change != 0)
                    {
                        if (change == change2)
                        {
                            change2 = which_kind.Next(1, 7);
                        }
                        else if (change == change3)
                        {
                            change3 = which_kind.Next(1, 7);
                        }
                        else if (change2 == change3)
                        {
                            change3 = which_kind.Next(1, 7);
                        }
                        else
                        {
                            break;
                        }
                    }
                    ChangeValue(9, change);
                    ChangeValue(9, change2);
                    ChangeValue(9, change3);
                }
            }
            displayMessage.text = " ";
        }
        else if (eventNum >= 41 && eventNum <= 50) // A little kid politely asks for a cookie, but he doesn't have any money
        {
            displayMessage.text = "Hi, Mister Deliveryman, could I have a cookie, please? I don't have any money, though...".ToString();
            choice = PlayerChoice.ReturnUserInput();
            if (choice == true)
            {
                System.Random random2 = new System.Random();
                int type = random2.Next(1, 7);
                while (type != 0)
                {
                    if (cookies[type - 1] < 1)
                    {
                        type = random2.Next(1, 7);
                    }
                    else
                    {
                        break;
                    }
                }
                ChangeValue(8, -1);
            }
            displayMessage.text = " ";
        }
        else if (eventNum >= 51 && eventNum <= 85) // Standard sale of a cookie
        {
            displayMessage.text = "Hi, you wouldn't happen to have a spare " + cookie_name[index - 1] + " cookie I could buy, would you?".ToString();
            choice = PlayerChoice.ReturnUserInput();
            if (choice == true && cookies[index - 1] > 0)
            {
                ChangeValue(index, -1);
                displayMessage.text = " ";
            }
            else if (choice == true && cookies[index - 1] <= 0)
            {
                displayMessage.text = "Oh, dear. It seems as though you don't have enough to fulfill the request.".ToString();
            }
        }
        else if (eventNum >= 86 && eventNum <= 100) // Sale of Multiple of one Cookie
        {
            System.Random random2 = new System.Random();
            int change = random2.Next(2, 6); // Sale of between 2 and 5 of the same cookie
            displayMessage.text = "Hi, could I buy " + change + " " + cookie_name[index - 1] + " cookies from you?".ToString();
            choice = PlayerChoice.ReturnUserInput();
            if (choice == true && cookies[index - 1] >= change)
            {
                ChangeValue(index, -change);
                displayMessage.text = " ";
            }
            else if (choice == true && cookies[index - 1] < change)
            {
                displayMessage.text = "Oh, dear. It seems as though you don't have enough to fulfill the request.".ToString();
            }
        }
    }

    public void OnHouseEventNum(int eventNum)
    {
        System.Random random = new System.Random();
        int index = random.Next(1, 7);
        int change;
        bool choice;
        
        if (eventNum >= 1 && eventNum <= 40) //Standard Sale of a single cookie
        {
            displayMessage.text = "Hello, I ordered one " + cookie_name[index - 1] + "cookie. Have you come to deliver it?".ToString();
            choice = PlayerChoice.ReturnUserInput();
            if (choice == true && cookies[index - 1] > 0)
            {
                ChangeValue(index, -1);
                displayMessage.text = " ";
            }
            else if (choice == true && cookies[index - 1] <= 0)
            {
                displayMessage.text = "Oh, dear. It seems as though you don't have enough to fulfill the order.".ToString();
            }
            //else if (choice == false)
            //{
            //     Rejection message. This will need to go on every instance if we decide to do it.
            //}
        }
        else if (eventNum >= 41 && eventNum <= 65) // Sale of Multiple of One Type of Cookie
        {
            System.Random random2 = new System.Random();
            change = random2.Next(2, 6); // Sale of between 2 and 5 of the same cookie
            displayMessage.text = "Hello, I ordered " + change + " " + cookie_name[index - 1] + "cookies. Have you come to deliver them?".ToString();
            choice = PlayerChoice.ReturnUserInput();
            if (choice == true && cookies[index - 1] >= change)
            {
                ChangeValue(index, -change);
                displayMessage.text = " ";
            }
            else if (choice == true && cookies[index - 1] < change)
            {
                displayMessage.text = "Oh, dear. It seems as though you don't have enough to fulfill the order.".ToString();
            }
        }
        else if (eventNum >= 66 && eventNum <= 80) // Sale of Multiple Types of Cookies
        {
            int index2;
            int change2;
            System.Random random2 = new System.Random();
            change = random2.Next(1, 4);
            change2 = random2.Next(2, 4); // 1 to 3 for the first type, 2 or 3 for the second
            System.Random random3 = new System.Random();
            index2 = random3.Next(1, 7);
            while (index != 0) // Prevents the same type from being sold twice
            {
                if (index == index2)
                {
                    index2 = random3.Next(1, 7);
                }
                else
                {
                    break;
                }
            }
            displayMessage.text = "Hello, I ordered " + change + " " + cookie_name[index - 1] + " and " + change2 + cookie_name[index2 - 1] +" cookies. Have you come to deliver them?".ToString();
            choice = PlayerChoice.ReturnUserInput();
            if (choice == true && cookies[index - 1] >= change && cookies[index2 - 1] >= change2)
            {
                ChangeValue(index, -change);
                ChangeValue(index2, -change2);
                displayMessage.text = " ";
            }
            else if (choice == true && (cookies[index - 1] < change || cookies[index2 - 1] < change2))
            {
                displayMessage.text = "Oh, dear. It seems as though you don't have enough to fulfill the order.".ToString();
            }
        }
        else if (eventNum >= 81 && eventNum <= 90)
        {
            displayMessage.text = "Hello, I ordered one of each cookie. Have you come to deliver them?".ToString();
            choice = PlayerChoice.ReturnUserInput();
            if (choice == true && cookies[0] > 0 && cookies[1] > 0 && cookies[2] > 0 && cookies[3] > 0 && cookies[4] > 0 && cookies[5] > 0)
            {
                ChangeValue(1, -1);
                ChangeValue(2, -1);
                ChangeValue(3, -1);
                ChangeValue(4, -1);
                ChangeValue(5, -1);
                ChangeValue(6, -1);
                displayMessage.text = " ";
            }
            else if (choice == true && (cookies[0] < 1 || cookies[1] < 1 || cookies[2] < 1 || cookies[3] < 1 || cookies[4] < 1 || cookies[5] < 1))
            {
                displayMessage.text = "Oh, dear. It seems as though you don't have enough to fulfill the order.".ToString();
            }
        }
        else if (eventNum >= 91 && eventNum <= 100)
        {
            displayMessage.text = "Hello, I ordered one " + cookie_name[index - 1] + "cookie. Have you come to deliver it? I'll give you a tip if you did.".ToString();
            choice = PlayerChoice.ReturnUserInput();
            if (choice == true && cookies[index - 1] > 0)
            {
                ChangeValue(index, -1);
                ChangeValue(7, 7);
                displayMessage.text = " ";
            }
            else if (choice == true && cookies[index - 1] <= 0)
            {
                displayMessage.text = "Oh, dear. It seems as though you don't have enough to fulfill the order.".ToString();
            }
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
        if (index >= 1 && index <= 6) // General sale events, will ALWAYS INVOLVE selling cookies for money. Checked in the event loops whether or not they can be done. If it got here, they can be.
        {
            cookies[index - 1] += change; // Change is negative
            UpdateBank();
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
            int lost = random.Next(1, 7);
            while (lost != 0)
            {
                if (cookies[lost - 1] <= 0)
                {
                    lost = random.Next(1, 7);
                }
                else
                {
                    break;
                }
            }
            cookies[lost - 1] += change;
            UpdateInventory();
        }
        else if (index == 9) // Gained inventory, but money was not involved
        {
            System.Random random = new System.Random();
            int gained = random.Next(1, 4);
            cookies[change - 1] += gained;
            UpdateInventory();
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
