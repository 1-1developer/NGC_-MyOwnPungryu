using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchLocation
{
    public int touchId;
    public GameObject circle;

    public TouchLocation(int newTouchID, GameObject newCircle)
    {
        touchId = newTouchID;
        circle = newCircle;
    }
}
