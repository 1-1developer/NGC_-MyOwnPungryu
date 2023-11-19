using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDropButtons : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public AudioClip[] audioClips;
    private AudioSource audioSource;
    private Rigidbody2D myRigidbody;
    private CanvasGroup canvasGroup;
    //private CircleCollider2D circleCollider;
    //[HideInInspector] public RectTransform instrumentButtonRectTransform;

    public bool inSlot;

    //////////////////////// Touch Drag ////////////////////////////
    public void OnBeginDrag(PointerEventData data)
    {
        //transform.position = data.position;
        //myRigidbody.MovePosition(data.position);
        canvasGroup.blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData data)
    {
        myRigidbody.MovePosition(data.position);
    }
    public void OnEndDrag(PointerEventData data)
    {
        //myRigidbody.MovePosition(data.position);
        canvasGroup.blocksRaycasts = true;
    }
    //////////////////////// Touch Drag ////////////////////////////

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        canvasGroup = GetComponent<CanvasGroup>();
        //circleCollider = GetComponent<CircleCollider2D>();
        //instrumentButtonRectTransform = GetComponent<RectTransform>();

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

            //inSlot = false;
        }

        //////////////////////// Positioning to Slot ////////////////////////////

        if (other.gameObject.CompareTag("Instrument Slot"))
        {
            if (audioSource.isPlaying)
            {
                audioSource.mute = true;
            }

            inSlot = true;
            //circleCollider.isTrigger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Instrument Slot"))
        {
            inSlot = false;
            //circleCollider.isTrigger = false;
        }
    }

    public bool IsInSlot()
    {
        Debug.Log("Is in Slot");
        return inSlot;
    }
}
