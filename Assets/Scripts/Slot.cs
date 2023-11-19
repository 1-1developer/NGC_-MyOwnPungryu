using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{
    private bool isEmpty;

    private RectTransform slotRectTransform;


    void Awake()
    {
        isEmpty = true;
        slotRectTransform = GetComponent<RectTransform>();
    }

    public void OnDrop(PointerEventData data)
    {
        if(data.pointerDrag != null)
        {
            //data.pointerDrag.transform.DOMove(slotRectTransform.anchoredPosition, 1.0f);
            data.pointerDrag.GetComponent<RectTransform>().anchoredPosition = slotRectTransform.localPosition;
            //gameObject.GetComponent<CircleCollider2D>().isTrigger = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isEmpty)
        {
            Debug.Log("Not Empty");
            //other.transform.DOMove(transform.position, 0.3f);
            isEmpty = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isEmpty = true;
        Debug.Log("Empty");
    }

    public bool IsEmpty() { return isEmpty; }
}
