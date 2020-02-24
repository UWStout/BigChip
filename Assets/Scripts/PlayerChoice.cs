using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerChoice : MonoBehaviour
{
    public Button Choice;
    public Button Other;
    private static bool user;
    int numOfEvents;
    public PlayerMovement playermovement;
    public Inventory inventory;
    public EventTimer timer;

    void Start()
    {
        Button btn = Choice.GetComponent<Button>();
        btn.onClick.AddListener(OnMouseDown);
    }

    void OnMouseDown()
    {
        if (Choice.name == "Confirm Button")
        {
            //Debug.Log("You have chosen the Confirm option");
            user = true;
        }
        else if (Choice.name == "Reject Button")
        {
           // Debug.Log("You have chosen the Reject option");
            user = false;
        }
        //turns the buttons off
        Choice.transform.gameObject.SetActive(false);
        Other.transform.gameObject.SetActive(false);
        inventory.displayMessage.text = "";

        //restarts the event timer
        timer.currentCoroutine = timer.StartCoroutine(timer.TriggerEvent());
        playermovement.IsHeMoving(); // Makes him move again
    }

    public static bool ReturnUserInput()
    {
        return user;
    }

    public void TestingAction()
    {
        numOfEvents += 1;
        playermovement.IsHeMoving(); // Pauses him
        inventory.GenNumber(); // Runs all the events
    }
}
