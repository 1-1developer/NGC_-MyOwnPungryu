using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDropButtons : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public AudioClip[] audioClips;
    private AudioSource audioSource;
    private int audioIndex;
    bool isDropped;
  
    //////////////////////// 터치 드래그 ////////////////////////////
    public void OnBeginDrag(PointerEventData data)
    {
        transform.position = data.position;
        //Debug.Log("Begin Drag");
    }
    public void OnDrag(PointerEventData data)
    {
        transform.position = data.position;
    }
    public void OnEndDrag(PointerEventData data)
    {
        transform.position = data.position;
        //Debug.Log("End Drag");
    }
    //////////////////////// 터치 드래그 ////////////////////////////

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
    }

    void Update()
    {
        if(!audioSource.isPlaying && AudioManager.isMusicStarted ==true)
        {
            audioSource.Play();
            audioSource.mute = true;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {        
        if(other.gameObject.CompareTag("Play Music Area")){

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
        
        if (other.gameObject.CompareTag("Off Music Area"))
        {
            Debug.Log("Mute Music");
            if (audioSource.isPlaying)
            {
                audioSource.mute = true;
            }
        }
    }

    public void StopMusic()
    {

    }

    // Singleton
    private static DragDropButtons _Instance;
    public static DragDropButtons Instance
    {
        get
        {
            if (_Instance == null)
            {
                _Instance = FindAnyObjectByType<DragDropButtons>();
            }
            return _Instance;
        }
    }

}
