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

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Full Slot");
        if (isEmpty)
        {
            other.transform.DOMove(transform.position, 0.5f);
            isEmpty = false;
        }
    }
    private void  OnTriggerStay(Collider other)
    {

        
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Empty Slot");
        isEmpty = true;
    }
}
