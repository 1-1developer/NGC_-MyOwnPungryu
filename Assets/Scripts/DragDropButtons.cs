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


    //////////////////////// Touch Drag ////////////////////////////
    public void OnBeginDrag(PointerEventData data)
    {
        //transform.position = data.position;
        myRigidbody.MovePosition(data.position);
    }
    public void OnDrag(PointerEventData data)
    {
        myRigidbody.MovePosition(data.position);
    }
    public void OnEndDrag(PointerEventData data)
    {
        myRigidbody.MovePosition(data.position);
    }
    //////////////////////// Touch Drag ////////////////////////////

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
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
                Debug.Log("On Music");
                audioSource.Play();
                AudioManager.isMusicStarted = true;
            }
        }

        //////////////////////////// Mute Music ////////////////////////////

        if (other.gameObject.CompareTag("Off Music Area"))
        {

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
}
