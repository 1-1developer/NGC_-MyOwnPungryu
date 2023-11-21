using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{
    public bool isEmpty;

    private RectTransform slotRectTransform;


    void Awake()
    {
        isEmpty = false;
        slotRectTransform = GetComponent<RectTransform>();
    }

    public void OnDrop(PointerEventData data)
    {
        if(data.pointerDrag != null)
        {
            //data.pointerDrag.transform.DOMove(slotRectTransform.anchoredPosition, 1.0f);
            
            data.pointerDrag.GetComponent<RectTransform>().anchoredPosition = slotRectTransform.anchoredPosition;
            isEmpty = false;
            //data.pointerDrag.transform.SetParent(this.transform);
        }
    }

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (isEmpty)
    //    {
    //        other.transform.GetComponent<RectTransform>().DOAnchorPos(slotRectTransform.localPosition, 0.3f);
    //        isEmpty = false;

    //    }
    //}

    private void OnTriggerExit2D(Collider2D other)
    {
        isEmpty = true;
    }

    public bool IsEmpty() { return isEmpty; }
}
