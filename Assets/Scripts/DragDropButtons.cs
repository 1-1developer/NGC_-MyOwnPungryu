using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class DragDropButtons : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private AudioSource audioSource;
    private Rigidbody2D myRigidbody;
    private CanvasGroup canvasGroup;
    private Canvas rootCanvas;
    private RectTransform myPosition;

    public bool inSlot;

    [HideInInspector] public Vector2 returnPosition;
    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        canvasGroup = GetComponent<CanvasGroup>();
        this.rootCanvas = this.GetComponentInParent<Canvas>();
        myPosition = GetComponentInParent<RectTransform>();



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
        returnPosition = myPosition.anchoredPosition;

        // if clicked set as last sibling
        gameObject.transform.SetAsLastSibling();


        canvasGroup.blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData data)
    {
        float clampPositionX = Mathf.Clamp(data.position.x, 30.0f, 1630.0f);
        float clampPositionY = Mathf.Clamp(data.position.y, 0.0f, 750.0f);
        myRigidbody.MovePosition(new Vector2(clampPositionX, clampPositionY));
    }
    public void OnEndDrag(PointerEventData data)
    {
        canvasGroup.blocksRaycasts = true;
    }

    public void ReturnToParent()
    {
        this.transform.SetParent(this.rootCanvas.transform);
    }
    public void ReturnPosition()
    {
        myPosition.anchoredPosition = returnPosition;
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
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        //////////////////////////// Mute Music ////////////////////////////

        if (other.gameObject.CompareTag("Play Music Area"))
        {
            if (audioSource.isPlaying)
            {
                audioSource.mute = true;
            }
        }
    }

    public bool IsInSlot()
    {
        return inSlot;
    }
}
