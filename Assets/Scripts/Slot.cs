using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private bool isEmpty;
    // Start is called before the first frame update
    void Start()
    {
        isEmpty = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Full Slot");
        if (isEmpty)
        {
            other.transform.DOMove(transform.position, 0.5f);
            //other.attachedRigidbody.bodyType = RigidbodyType2D.Kinematic;
            isEmpty = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //other.attachedRigidbody.bodyType = RigidbodyType2D.Dynamic;
        Debug.Log("Empty Slot");
        isEmpty = true;
    }

    public bool IsEmpty() {  return isEmpty; }
}
