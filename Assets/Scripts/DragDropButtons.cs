using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDropButtons : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private AudioSource audioSource;
    private Rigidbody2D myRigidbody;
    private CanvasGroup canvasGroup;
    private Canvas rootCanvas;

    public bool inSlot;

    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        canvasGroup = GetComponent<CanvasGroup>();
        this.rootCanvas = this.GetComponentInParent<Canvas>();

        inSlot = true;
    }

    void Update()
    {
        if (!audioSource.isPlaying && AudioManager.isMusicStarted == true)
        {
            audioSource.Play();
            audioSource.mute = true;
        }
    }

    /////////////////////////// Touch Drag ///////////////////////////////
    public void OnBeginDrag(PointerEventData data)
    {
        //transform.position = data.position;

        // set parent to root canvas
        this.transform.SetParent(rootCanvas.transform);

        // if clicked set as last sibling
        gameObject.transform.SetAsLastSibling();


        canvasGroup.blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData data)
    {
        myRigidbody.MovePosition(data.position);
    }
    public void OnEndDrag(PointerEventData data)
    {
        canvasGroup.blocksRaycasts = true;
    }

    public void ReturnToParent()
    {
        this.transform.SetParent(this.rootCanvas.transform);
    }

    /////////////////////////// Touch Drag ///////////////////////////////
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        //////////////////////////// Play Music ////////////////////////////

        if (other.gameObject.CompareTag("Play Music Area"))
        {

            if (audioSource.isPlaying)
            {
                audioSource.mute = false;
            }
            else
            {
                audioSource.Play();
                AudioManager.isMusicStarted = true;
            }

            inSlot = false;
        }

        //////////////////////// Positioning to Slot ////////////////////////////

        if (other.gameObject.CompareTag("Instrument Slot"))
        {
            if (audioSource.isPlaying)
            {
                audioSource.mute = true;
            }         
        }
    }

    //private void OnTriggerExit2D(Collider2D other)
    //{
    //    if (other.gameObject.CompareTag("Instrument Slot"))
    //    {
    //        inSlot = false;            
    //    }
    //}

    public bool IsInSlot()
    {
        Debug.Log("Is in Slot");
        return inSlot;
    }
}
