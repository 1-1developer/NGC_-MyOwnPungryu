using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{

    private RectTransform slotRectTransform;


    void Awake()
    {
        slotRectTransform = GetComponent<RectTransform>();
    }

    public void OnDrop(PointerEventData data)
    {
        DragDropButtons dragDropButton = data.pointerDrag.gameObject.GetComponent<DragDropButtons>();

        if(this.transform.childCount == 0)
        {
           
            data.pointerDrag.GetComponent<RectTransform>().anchoredPosition = slotRectTransform.localPosition;
            data.pointerDrag.transform.SetParent(this.transform);
            dragDropButton.inSlot = true;
        }
        else
        {
            dragDropButton.ReturnToParent();
            dragDropButton.inSlot = false;
        }

        //if(data.pointerDrag != null)
        //{
        //    //data.pointerDrag.transform.DOMove(slotRectTransform.anchoredPosition, 1.0f);
            
        //    data.pointerDrag.GetComponent<RectTransform>().anchoredPosition = slotRectTransform.anchoredPosition;
        //    isEmpty = false;
        //    //data.pointerDrag.transform.SetParent(this.transform);
        //}
    }
}
