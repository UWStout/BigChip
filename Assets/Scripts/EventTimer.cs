using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class EventTimer : MonoBehaviour
{
    public Button Accept;
    public Button Decline;
    private static bool? user;
    int numOfEvents;
    public PlayerMovement playermovement;
    public Inventory inventory;


    [Range(3, 15)]
    public float waitTime;

    public Coroutine currentCoroutine = null;

    //Should be called again after the event stops
    public IEnumerator TriggerEvent()
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime); //wait for time then continue
            Debug.Log("An Event would trigger now");
            Accept.transform.gameObject.SetActive(true);
            Decline.transform.gameObject.SetActive(true);
            //StopEvent();
            //TestingAction();
            //function call for trigger
        }
    }


    //time set needs to be longer than the trigger
    public void StopEvent()
    {
        Debug.Log("New events have stopped");
        StopCoroutine(currentCoroutine);
    }

    void Start()
    {
        currentCoroutine = StartCoroutine(TriggerEvent());
        Button btn = Accept.GetComponent<Button>();
        btn.onClick.AddListener(OnMouseDown);
        Button bttn = Decline.GetComponent<Button>();
        bttn.onClick.AddListener(OnMouseDown);
        user = null;
    }

    void OnMouseDown()
    {
        if (user == null)
        {

            if (Accept)
            {
                Debug.Log("You have chosen the Confirm option");
                user = true;
            }
            else if (Decline)
            {
                Debug.Log("You have chosen the Reject option");
                user = false;
            }

            Accept.transform.gameObject.SetActive(false);
            Decline.transform.gameObject.SetActive(false);
            user = null; // testing
        }
    }

    public static bool? ReturnUserInput()
    {
        return user;
    }

    public void TestingAction()
    {
        numOfEvents += 1;
        playermovement.IsHeMoving(); // Pauses him
        inventory.GenNumber(); // Runs all the events
        currentCoroutine = StartCoroutine(TriggerEvent()); //restarts events
        playermovement.IsHeMoving(); // Makes him move again
        user = null;
    }
}
