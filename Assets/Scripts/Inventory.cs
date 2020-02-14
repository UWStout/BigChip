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

        //the last element in the array should be a 6 now
        //quick test to see if i can change the amount within a script
        cookies[5] -= 3;

        foreach (int value in cookies)
        {
            print(value);
        }
    }
}
