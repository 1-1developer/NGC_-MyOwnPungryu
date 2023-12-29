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
    private ParticleSystem myparticle;
    private UnityEngine.UI.Slider mySlider;
    private Animator slider_anim;

    public bool inSlot;
    private float timer;

    [HideInInspector] public Vector2 returnPosition;
    [HideInInspector] public Transform parentAfterDrag;

    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        canvasGroup = GetComponent<CanvasGroup>();
        this.rootCanvas = this.GetComponentInParent<Canvas>();
        myPosition = GetComponentInParent<RectTransform>();
        myparticle = GetComponentInChildren<ParticleSystem>();
        mySlider = GetComponentInChildren<UnityEngine.UI.Slider>();
        inSlot = true;
        myparticle.Stop();
        mySlider.gameObject.SetActive(false);
        slider_anim = mySlider.GetComponent<Animator>();
    }

    void Update()
    {
        if (!audioSource.isPlaying && AudioManager.isMusicStarted == true)
        {
            audioSource.Play();
            audioSource.mute = true;
        }
        if (inSlot) //슬롯에 있을때 이펙트 정지 
        {
            myparticle.Stop(); myparticle.Clear();
        }
        if (mySlider.IsActive()) //볼륨슬라이더 조절
        {
            timer += Time.deltaTime;
            audioSource.volume = mySlider.value;
            if (timer > 2.6f)
                slider_anim.SetTrigger("Out");
            if (timer > 3f)
            {
                mySlider.gameObject.SetActive(false);
                timer = 0;
            }
            if (timer <= 0)
            {
                timer = 0;
            }
        }
    }
    public void autoInit()
    {
        audioSource.Play();
        audioSource.mute = true;
        audioSource.mute = false;
    }
    public void addTime()
    {
        timer-=0.1f;
    }
    /////////////////////////// Touch Drag ///////////////////////////////
    public void OnBeginDrag(PointerEventData data)
    {
        // transform.position = data.position;

        // set parent to root canvas
        parentAfterDrag = transform.parent;
        this.transform.SetParent(rootCanvas.transform);
        returnPosition = myPosition.anchoredPosition;

        // if clicked set as last sibling
        gameObject.transform.SetAsLastSibling();

        canvasGroup.blocksRaycasts = false;
        mySlider.gameObject.SetActive(true);
    }
    public void OnDrag(PointerEventData data)
    {
        /*
        //float distance = Vector3.Distance(myPosition.position, data.position);
        //float maxDistance = 80f;
        //if(distance > maxDistance * rootCanvas.scaleFactor)
        //{
        //    myRigidbody.MovePosition(data.position.normalized*(maxDistance* rootCanvas.scaleFactor));
        //}
        //else
        //{
        //}
        //float clampPositionX = Mathf.Clamp(data.position.x, 30.0f, 1480);
        //float clampPositionY = Mathf.Clamp(data.position.y, 0.0f, 10000f);
        //myRigidbody.MovePosition(new Vector2(clampPositionX, clampPositionY));

        //myRigidbody.MovePosition(new Vector2(data.position.x, data.position.y));
        */

        //드래그 포지션 제한
        float clampPositionX = Mathf.Clamp((myPosition.anchoredPosition + data.delta / data.clickCount).x, -700f, 700);
        float clampPositionY = Mathf.Clamp((myPosition.anchoredPosition + data.delta / data.clickCount).y, -400f, 300);

        myPosition.anchoredPosition = new Vector2(clampPositionX, clampPositionY);
    }
    public void OnEndDrag(PointerEventData data)
    {
        canvasGroup.blocksRaycasts = true; //드래그-가능 상대로 전환
    }

    public void ReturnToParent()
    {
        this.transform.SetParent(this.rootCanvas.transform);
    }
    public void ReturnPosition()
    {      
        //if (inSlot)
        //{
        //    myPosition.DOAnchorPos(new Vector2(0, 0), 0.4f);
        //}
        //else
        //{
        //    myPosition.DOAnchorPos(returnPosition, 0.4f);
        //}
        myPosition.anchoredPosition = returnPosition;
        //myPosition.DOAnchorPos(returnPosition, 0.5f);
        transform.SetParent(parentAfterDrag);
    }
    /////////////////////////// Touch Drag ///////////////////////////////
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        //////////////////////////// Play Music ////////////////////////////

        if (other.gameObject.CompareTag("Play Music Area"))
        {
            myparticle.Play();

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
                myparticle.Stop(); myparticle.Clear();
            }
        }
    }

    public bool IsInSlot()
    {
        return inSlot;
    }
}
