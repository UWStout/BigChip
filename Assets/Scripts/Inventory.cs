using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int[] cookies;
    public int[] price;
    public int bank;
    public GameplayManager _bankSend;


    void Start()
    {
        //initialize the array with a size
        //unity doesnt like to change size
        //we dont need to so we should be ok
        int[] cookies = new int[7]; // This is going to have a blank index spot for special events. Only the first six are cookies.
        int[] price = new int[6];

        //currently hardcode to set values into the array
        cookies.SetValue(8, 0);
        cookies.SetValue(6, 1);
        cookies.SetValue(7, 2);
        cookies.SetValue(5, 3);
        cookies.SetValue(3, 4);
        cookies.SetValue(9, 5);

        //hardcoded to give each cookie a specific price
        price.SetValue(5, 0);
        price.SetValue(10, 1);
        price.SetValue(10, 2);
        price.SetValue(8, 3);
        price.SetValue(8, 4);
        price.SetValue(5, 5);
    }


    // IMPORTANT NOTE 
    // The index goes from 1-6 in reference to the 6 elements in our list

    // index controls which element in the array is going to alter
    // change can be positive or negative which will subtract or add the amount
    // error msg will print if an index is too high
    public void ChangeValue(int index, int change)
    {
        if (index == 1)
        {
            if (change < 0)
            {
                if (change - cookies[0] < 0)
                {
                    change = cookies[0];
                }
                cookies[0] -= change;
            }
            else if (change > 0)
            {
                cookies[0] += change;
            }

        }else if(index == 2)
        {
            if (change < 0)
            {
                if (change - cookies[1] < 0)
                {
                    change = cookies[1];
                }
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
                if (change - cookies[2] < 0)
                {
                    change = cookies[2];
                }
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
                if (change - cookies[3] < 0)
                {
                    change = cookies[3];
                }
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
                if (change - cookies[4] < 0)
                {
                    change = cookies[4];
                }
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
                if (change - cookies[5] < 0)
                {
                    change = cookies[5];
                }

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

        if (index >= 1 && index <= 6)
        {
            bank = price[index - 1] * change;
            _bankSend.UpdateBank(bank);
        }
        else if (index == 7)
        {
            bank = change;
            _bankSend.UpdateBank(bank);
        }
    }
}
