using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine.TestTools;

public class MainSceneUI : MonoBehaviour
{
    [SerializeField]
    private RectTransform shelfLeftTransform;
    [SerializeField]
    private RectTransform shelfRIghtTransform;
    [SerializeField]
    private GameObject dragInstrumentUI;
    [SerializeField]
    private GameObject tutorial;
    [SerializeField]
    private GameObject AudioButtons;    

    [SerializeField]
    private List<GameObject> instrumentButtons;
    [SerializeField]
    private List <RectTransform> instrumentButtonTransform;

    [SerializeField]
    private List<GameObject> slots;
    [SerializeField]
    private List<RectTransform> slotTransform;



    private Vector2 initial_shelfLeftTransform;
    private Vector2 initial_shelfrightTransform;

    [HideInInspector] public bool isShelfOn;
    [HideInInspector] public int audioIndex;


    void Start()
    {
        // Language Data Set
        int languageSprite = Title.selectLanguage;
        Debug.Log("Language Mode: "+languageSprite);

        // Shelf Initial Position Setting
        initial_shelfLeftTransform = shelfLeftTransform.anchoredPosition;
        initial_shelfrightTransform = shelfRIghtTransform.anchoredPosition;

        for (int i = 0; i < 4; i++) {
            instrumentButtonTransform[i].anchoredPosition = new Vector2(initial_shelfLeftTransform.x, slotTransform[i].anchoredPosition.y);
        }
        for (int i = 3; i < instrumentButtonTransform.Capacity; i++)
        {
            instrumentButtonTransform[i].anchoredPosition = new Vector2(initial_shelfrightTransform.x, slotTransform[i].anchoredPosition.y);
        }
        for (int i = 3; i < instrumentButtonTransform.Capacity; i++)
        {
            instrumentButtonTransform[i].anchoredPosition = new Vector2(initial_shelfrightTransform.x, slotTransform[i].anchoredPosition.y);
        }



        isShelfOn = false;

        dragInstrumentUI.SetActive(false);
    }


    // Home Button
    public void OnClickHomeButton()
    {
        SceneManager.LoadScene("Title");
    }

    
    // Music Select & Activate Shelf
    public void OnClickAudioSelectButton(int n)
    {
        isShelfOn = true;

        audioIndex = n;
        AudioManager.Instance.SetAudioClips(audioIndex);
                
        dragInstrumentUI.SetActive(true);
        OnInstrumentSelection();
    }

    // Deactivate Shelf
    public void OnClickCloseButton()
    {
        isShelfOn = false;

        AudioManager.Instance.StopAudioSources();

        dragInstrumentUI.SetActive(false);
        tutorial.SetActive(true);
        OffInstrumentSelection();
    }
    // Audio Selection UI

    float moveRange = 200.0f;
    public void OnInstrumentSelection()
    {

        shelfLeftTransform.DOAnchorPosX(initial_shelfLeftTransform.x + moveRange, 1.0f);
        shelfRIghtTransform.DOAnchorPosX(initial_shelfrightTransform.x - moveRange, 1.0f);

        for (int i = 0; i < instrumentButtonTransform.Capacity; i++)
        {
            if (i < 3)
            {
                slotTransform[i].DOAnchorPosX(initial_shelfLeftTransform.x + moveRange, 1.0f);
            }
            else
            {
                slotTransform[i].DOAnchorPosX(initial_shelfrightTransform.x - moveRange, 1.0f);
            }

            if (instrumentButtonTransform[i].anchoredPosition.x < 0)
            {
                instrumentButtonTransform[i].DOAnchorPosX(initial_shelfLeftTransform.x + moveRange, 1.0f);
            }
            else
            {
                instrumentButtonTransform[i].DOAnchorPosX(initial_shelfrightTransform.x - moveRange, 1.0f);
            }
        }
    }
    public void OffInstrumentSelection()
    {
        ResetInstrumentButtons();
        shelfLeftTransform.DOAnchorPosX(initial_shelfLeftTransform.x, 1.0f);
        shelfRIghtTransform.DOAnchorPosX(initial_shelfrightTransform.x, 1.0f);

        for (int i = 0; i < instrumentButtonTransform.Capacity; i++)
        {
            if (i < 3)
            {
                slotTransform[i].DOAnchorPosX(initial_shelfLeftTransform.x, 1.0f);
            }
            else
            {
                slotTransform[i].DOAnchorPosX(initial_shelfrightTransform.x, 1.0f);
            }
            //if (instrumentButtonTransform[i].anchoredPosition.x < 0)
            //{
            //    instrumentButtonTransform[i].DOAnchorPosX(initial_shelfLeftTransform.x , 1.0f);
            //}
            //else
            //{
            //    instrumentButtonTransform[i].DOAnchorPosX(initial_shelfrightTransform.x , 1.0f);
            //}
        }


    }

    public void ResetInstrumentButtons()
    {
        for (int i = 0; i < instrumentButtons.Capacity; i++)
        {
            if (!instrumentButtons[i].GetComponent<DragDropButtons>().IsInSlot())
            {
                for (int k = 0; k < slots.Capacity; k++)
                {
                    if (slots[k].GetComponent<Slot>().IsEmpty())
                    {
                        Vector2 minDistanceSlot = slotTransform[k].anchoredPosition;
                        int curSlotIndex = k;
                        for (int j = k + 1; j < instrumentButtons.Capacity; j++)
                        {
                            if (slots[j].GetComponent<Slot>().IsEmpty())
                            {
                                if (Vector2.Distance(minDistanceSlot, instrumentButtonTransform[i].anchoredPosition) >
                                Vector2.Distance(slotTransform[j].anchoredPosition, instrumentButtonTransform[i].anchoredPosition))
                                {
                                    minDistanceSlot = slotTransform[j].anchoredPosition;
                                    curSlotIndex = j;
                                }
                            }
                        }
                        slots[curSlotIndex].GetComponent<Slot>().isEmpty = false;
                        if(curSlotIndex < 3)
                        {
                            minDistanceSlot.x = initial_shelfLeftTransform.x;
                        }
                        else
                        {
                            minDistanceSlot.x = initial_shelfrightTransform.x;
                        }
                        instrumentButtonTransform[i].DOAnchorPos(minDistanceSlot, 1.0f);
                        break;
                    }
                }
            }
            else
            {
                if (instrumentButtonTransform[i].anchoredPosition.x < 0)
                {
                    instrumentButtonTransform[i].DOAnchorPosX(initial_shelfLeftTransform.x, 1.0f);
                }
                else
                {
                    instrumentButtonTransform[i].DOAnchorPosX(initial_shelfrightTransform.x, 1.0f);
                }
            }
        }
    }

    // Singleton
    private static MainSceneUI _Instance;
    public static MainSceneUI Instance
    {
        get
        {
            if (_Instance == null)
            {
                _Instance = FindAnyObjectByType<MainSceneUI>();
            }
            return _Instance;
        }
    }
}
