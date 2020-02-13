using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Money_System : MonoBehaviour
{
    public int bank;
    public Text bankText;

    void Start()
    {
        bank = 50;
        bankText.text = "Money: $" + bank.ToString();
    }

    public void addBank(int bankToAdd)
    {
        bank += bankToAdd;
        bankText.text = "Money: $" + bank.ToString();
    }

    public void subtractBank(int bankToSubtract)
    {
        if (bank - bankToSubtract < 0)
        {
            // Add to it Later
        }
        else
        {
            bank -= bankToSubtract;
            bankText.text = "Money: $" + bank.ToString();
        }
    }
}
