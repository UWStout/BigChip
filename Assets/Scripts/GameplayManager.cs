using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour
{
    public Text bankText;
    private int currentBank;

    public void UpdateBank(int bank)
    {
        currentBank += bank;
        bankText.text = "Money: $" + bank.ToString();
    }

}
