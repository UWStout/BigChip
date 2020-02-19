using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int[] cookies = new int[6];
    public int[] price = new int[6];
    public int bank;

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


    // IMPORTANT NOTE 
    // The index goes from 1-6 in reference to the 6 elements in our list
    // However, index can go higher during the case of a special event
    // index primarily controls which element in the array is going to alter
    // change can be positive or negative which will subtract or add the amount
    // error msg will print if an index is too high
    public void ChangeValue(int index, int change)
    {
        if (index >= 1 && index <= 6)
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
        else if (index == 7)
        {
            bank = change;
            UpdateBank();
        }
        else
        {
            print("Number is not in reference to inventory list");
        }
    }

    public void UpdateBank()
    {
        currentBank += bank;
        bankText.text = "Money: $" + currentBank.ToString();
    }

    public void UpdateInventory()
    {
        cookie1.text = cookies[0].ToString();
        cookie2.text = cookies[1].ToString();
        cookie3.text = cookies[2].ToString();
        cookie4.text = cookies[3].ToString();
        cookie5.text = cookies[4].ToString();
        cookie6.text = cookies[5].ToString();
    }
}
