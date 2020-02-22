using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScroll : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        Debug.Log("I'm gone");
    }

    private void OnBecameVisible()
    {
        Debug.Log("I'm seen");
    }
}