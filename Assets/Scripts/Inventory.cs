using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int[] cookies;



    void Start()
    {
        //initialize the array with a size
        //unity doesnt like to change size
        //we dont need to so we should be ok
        cookies = new int[6];

        //currently hardcode to set values into the array
        cookies.SetValue(8, 0);
        cookies.SetValue(6, 1);
        cookies.SetValue(7, 2);
        cookies.SetValue(5, 3);
        cookies.SetValue(3, 4);
        cookies.SetValue(9, 5);
    }


    // IMPORTANT NOTE 
    // The index goes from 1-6 in reference to the 6 elements in our list

    // index controls which element in the array is going to alter
    // change can be positive or negative which will subtract or add the amount
    // error msg will print if an index is too high
    void ChangeValue(int[] arr, int index, int change)
    {
        if (index == 1)
        {
            if (change < 0)
            {
                cookies[0] -= change;
            }else if (change > 0)
            {
                cookies[0] += change;
            }

        }else if(index == 2)
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
