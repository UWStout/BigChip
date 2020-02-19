using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;

public class PlayerChoice : MonoBehaviour
{
    public Button Choice;
    public Button Other;
    public bool user;
    public static bool isActive;

    void Start()
    { 
        Button btn = Choice.GetComponent<Button>();
        btn.onClick.AddListener(OnMouseDown);
        Choice.transform.gameObject.SetActive(false);
        Other.transform.gameObject.SetActive(false);
        isActive = false;
    }

    void OnMouseDown()
    {
        if (Choice.name == "Confirm Button")
        {
            Debug.Log("You have chosen the Confirm option");
            user = true;
        }
        else if (Choice.name == "Reject Button")
        {
            Debug.Log("You have chosen the Reject option");
            user = false;
        }

        Choice.transform.gameObject.SetActive(false);
        Other.transform.gameObject.SetActive(false);
        isActive = false;
    }

    public bool ReturnUserInput()
    {
        return user;
    }
}
