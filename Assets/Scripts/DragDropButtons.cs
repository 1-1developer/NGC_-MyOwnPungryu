using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDropButtons : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public List<AudioClip> audioClips;

    private AudioSource audioSource;
    private int audioIndex;
    bool isPlayingMusic;
  
    //////////////////////// 터치 드래그 ////////////////////////////
    public void OnBeginDrag(PointerEventData data)
    {
        transform.position = data.position;
    }
    public void OnDrag(PointerEventData data)
    {
        transform.position = data.position;
    }
    public void OnEndDrag(PointerEventData data)
    {
        transform.position = data.position;
    }
    //////////////////////// 터치 드래그 ////////////////////////////

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        isPlayingMusic = false;
    }

    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {        
        if(other.gameObject.CompareTag("Play Music Area")){
            int playAudioIndex = MainSceneUI.Instance.audioIndex;
            Debug.Log("playAudioIndex " + playAudioIndex);
            isPlayingMusic = true;            
            audioSource.mute = false;
            ////////////////need debug////////////////////
            audioSource.PlayOneShot(audioClips[playAudioIndex]);
        }
        if (other.gameObject.CompareTag("Off Music Area"))
        {
            Debug.Log("Mute");
            isPlayingMusic = false;
            audioSource.mute = true;
        }
    }


    // 싱글톤
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
