using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MultipleTouch : MonoBehaviour
{
    public GameObject circle;
    public List<TouchLocation> touches = new List<TouchLocation>();

    void Update()
    {
        int i = 0;
        while(i < Input.touchCount) {
            Touch t = Input.GetTouch(i);
            if (t.phase == TouchPhase.Began){

                Debug.Log("touch began");
                touches.Add(new TouchLocation(t.fingerId, CreateCircle(t)));
                              
            }
            else if (t.phase == TouchPhase.Moved){
                
                TouchLocation thisTouch = touches.Find(TouchLocation => TouchLocation.touchId == t.fingerId);
                thisTouch.circle.transform.position = getTouchPosition(t.position);                                       

            }
            else if (t.phase == TouchPhase.Ended){
                Debug.Log("touch ended");
                TouchLocation thisTouch = touches.Find(TouchLocation => TouchLocation.touchId == t.fingerId);
                Destroy(thisTouch.circle);
                touches.RemoveAt(touches.IndexOf(thisTouch));
            }
            i++;
        }
    }
    Vector2 getTouchPosition(Vector2 touchPosition)
    {
        return GetComponent<Camera>().ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, transform.position.z));
    }

    GameObject CreateCircle(Touch t)
    {
        GameObject c = Instantiate(circle) as GameObject;
        c.name = "Touch" + t.fingerId;
        c.transform.position = t.position;
        return c;
    }


}
