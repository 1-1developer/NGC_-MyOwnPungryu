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
    private GameObject playMusicArea;
    [SerializeField]
    private GameObject AudioButtons;
    [SerializeField]
    private List <GameObject> InstrumentButtonPrefab;


    private Vector2 initial_shelfLeftTransform;
    private Vector2 initial_shelfrightTransform;


    void Start()
    {
        // 언어 선택 데이터 받아오기
        int languageSprite = Title.selectLanguage;
        Debug.Log("Language Mode: "+languageSprite);

        // UI Initial Position Setting
        initial_shelfLeftTransform = shelfLeftTransform.anchoredPosition;
        initial_shelfrightTransform = shelfRIghtTransform.anchoredPosition;

        for (int i = 0; i < InstrumentButtonPrefab.Capacity; i++) {
            RectTransform InstrumentButtonPosition = InstrumentButtonPrefab[i].GetComponent<RectTransform>();
            if(i < 3)
            {
                InstrumentButtonPosition.anchoredPosition = new Vector2(initial_shelfLeftTransform.x, -350.0f - i * 300.0f) ;
            }
            else
            {
                InstrumentButtonPosition.anchoredPosition = new Vector2(initial_shelfrightTransform.x, -350.0f - (i-3) * 300.0f);
            }
        }
       
        playMusicArea.SetActive(false);
    }
    void Update()
    {
        
    }

    // 홈 버튼 누르면 타이틀로 이동
    public void OnClickHomeButton()
    {
        SceneManager.LoadScene("Title");
    }

    public int audioIndex;
    // 노래 선택 버튼
    public void OnClickAudioSelectButton(int n)
    {
        audioIndex = n;
        Debug.Log("AudioSource " + n + " selected");        
        AudioButtons.SetActive(false);
        playMusicArea.SetActive(true);
        OnInstrumentSelection();
    }

    // 선반 Close Button
    public void OnClickCloseButton()
    {
        OffInstrumentSelection();
        AudioButtons.SetActive(true);
        playMusicArea.SetActive(false);
    }
    // 악기 선택 UI
    public void OnInstrumentSelection()
    {
        float moveRange = 200.0f;
        shelfLeftTransform.DOAnchorPosX(initial_shelfLeftTransform.x + moveRange, 1.0f);
        shelfRIghtTransform.DOAnchorPosX(initial_shelfrightTransform.x - moveRange, 1.0f);
        for (int i = 0; i < InstrumentButtonPrefab.Capacity; i++)
        {
            RectTransform InstrumentButtonPosition = InstrumentButtonPrefab[i].GetComponent<RectTransform>();
            if (i < 3)
            {
                InstrumentButtonPosition.DOAnchorPosX(initial_shelfLeftTransform.x + moveRange, 1.0f);
            }
            else
            {
                InstrumentButtonPosition.DOAnchorPosX(initial_shelfrightTransform.x - moveRange, 1.0f);
            }
        }
    }
    public void OffInstrumentSelection()
    {
        shelfLeftTransform.DOAnchorPosX(initial_shelfLeftTransform.x, 1.0f);
        shelfRIghtTransform.DOAnchorPosX(initial_shelfrightTransform.x, 1.0f);
        for (int i = 0; i < InstrumentButtonPrefab.Capacity; i++)
        {
            RectTransform InstrumentButtonPosition = InstrumentButtonPrefab[i].GetComponent<RectTransform>();
            if (i < 3)
            {
                InstrumentButtonPosition.DOAnchorPos(new Vector2(initial_shelfLeftTransform.x, -350.0f - i * 300.0f), 1.0f);
            }
            else
            {
                InstrumentButtonPosition.DOAnchorPos(new Vector2(initial_shelfrightTransform.x, -350.0f - (i - 3) * 300.0f), 1.0f);
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
