using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine.TestTools;
using TMPro;

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

    [SerializeField] Image piri;
    [SerializeField] Image cursong;
    [SerializeField] Sprite[] piris;
    [SerializeField] Sprite[] songs;
    [SerializeField] TextMeshProUGUI piri_Tx;

    void Start()
    {
        // Language Data Set
        int languageSprite = LanguageID.selectLanguage;
        Debug.Log("Language Mode: "+languageSprite);

        // Shelf Initial Position Setting
        initial_shelfLeftTransform = shelfLeftTransform.anchoredPosition;
        initial_shelfrightTransform = shelfRIghtTransform.anchoredPosition;

        isShelfOn = false;

        dragInstrumentUI.SetActive(false);
        cursong.color = Color.clear;
    }

    // Home Button
    public void OnClickHomeButton()
    {
        AudioManager.PlayDefaultButtonSound();
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
        cursong.color = Color.white;

        AudioManager.PlayDefaultButtonSound();

        if (audioIndex ==0 ) //ch
        {
            piri.sprite = piris[1];
            if (LanguageID.selectLanguage == 0)
                cursong.sprite = songs[0];
            else
                cursong.sprite = songs[3];
        }
        else if(audioIndex == 1)//y
        {
            piri.sprite = piris[1];
            if (LanguageID.selectLanguage == 0)
                cursong.sprite = songs[1];
            else
                cursong.sprite = songs[4];
        }
        else if (audioIndex == 2)//t
        {
            piri.sprite = piris[0];
            if (LanguageID.selectLanguage == 0)
                cursong.sprite = songs[2];
            else
                cursong.sprite = songs[5];
        }
    }

    // Deactivate Shelf
    public void OnClickCloseButton()
    {
        isShelfOn = false;

        AudioManager.Instance.StopAudioSources();
        AudioManager.PlayDefaultButtonSound();

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
        }
    }

    public void ResetInstrumentButtons()
    {
        cursong.color = Color.clear;
        for (int i = 0; i < instrumentButtons.Capacity; i++)
        {
            DragDropButtons curDragDropButton = instrumentButtons[i].GetComponent<DragDropButtons>();
            if (!curDragDropButton.IsInSlot())
            {
                for (int k = 0; k < slots.Capacity; k++)
                {
                    if (slots[k].transform.childCount == 0)
                    {
                        Vector2 minDistanceSlot = slotTransform[k].anchoredPosition;
                        int curSlotIndex = k;
                        for (int j = k + 1; j < instrumentButtons.Capacity; j++)
                        {
                            if (slots[j].transform.childCount == 0)
                            {
                                if (Vector2.Distance(minDistanceSlot, instrumentButtonTransform[i].anchoredPosition) >
                                Vector2.Distance(slotTransform[j].anchoredPosition, instrumentButtonTransform[i].anchoredPosition))
                                {
                                    minDistanceSlot = slotTransform[j].anchoredPosition;
                                    curSlotIndex = j;
                                }
                            }
                        }
                        instrumentButtons[i].transform.SetParent(slots[curSlotIndex].transform);
                        curDragDropButton.inSlot = true;
                        instrumentButtonTransform[i].DOAnchorPos(new Vector2(0, 0), 1.0f);
                        break;
                    }
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
