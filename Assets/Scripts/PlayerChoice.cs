using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;

public class PlayerChoice : MonoBehaviour
{
    public Button Choice;
    public Button Other;
    private static bool user;
    int numOfEvents;
    public PlayerMovement playermovement;
    public Inventory inventory;
    public EventTimer eventtimer;
    

    void Start()
    { 
        Button btn = Choice.GetComponent<Button>();
        btn.onClick.AddListener(OnMouseDown);
        Choice.transform.gameObject.SetActive(false);
        Other.transform.gameObject.SetActive(false);
        EventTimer.Create(TestingAction, 5f);
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
    }

    public static bool ReturnUserInput()
    {
        return user;
    }

    private void TestingAction()
    {
        numOfEvents += 1;
        Choice.transform.gameObject.SetActive(true); // button selected
        Other.transform.gameObject.SetActive(true); // button not selected
        playermovement.IsHeMoving(); // Pauses him
        inventory.GenNumber(); // Runs all the events
        eventtimer.EndEvents(numOfEvents);
        playermovement.IsHeMoving(); // Makes him move again
     }
}
