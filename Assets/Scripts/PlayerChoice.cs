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

    void Start()
    {
        Button btn = Choice.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
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
    }

    public bool ReturnUserInput()
    {
        return user;
    }
}
