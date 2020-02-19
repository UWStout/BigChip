using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bg_Generation : MonoBehaviour
{
    public Transform BackDrop;
    public Transform BackDrop1;

    private bool Alternate;

    public Transform maincam;

    private float currentDistance = 15;

    void Update()
    {
        if(currentDistance < maincam.position.x)
        {
            if (Alternate)
                BackDrop.localPosition = new Vector3(BackDrop.localPosition.x + 30, 0, 10);
            else
                BackDrop1.localPosition = new Vector3(BackDrop1.localPosition.x + 30, 0, 10);

            currentDistance += 15;

            Alternate = !Alternate;
        }
        if(currentDistance > maincam.position.x + 15)
        {
            if (Alternate)
            {
                BackDrop1.localPosition = new Vector3(BackDrop1.localPosition.x - 30, 0, 10);
            }else
                BackDrop.localPosition = new Vector3(BackDrop.localPosition.x - 30, 0, 10);

            currentDistance -= 15;

            Alternate = !Alternate;
        }
    }

}
