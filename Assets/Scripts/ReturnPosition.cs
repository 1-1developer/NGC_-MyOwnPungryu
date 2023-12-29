using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ReturnPosition : MonoBehaviour, IDropHandler
{

    //private RectTransform initialPosition;
    public void OnDrop(PointerEventData data)
    {
        DragDropButtons dragDropButton = data.pointerDrag.gameObject.GetComponent<DragDropButtons>();
        dragDropButton.ReturnPosition();
    }
}
