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
        // ��� ���� ������ �޾ƿ���
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

    // Ȩ ��ư ������ Ÿ��Ʋ�� �̵�
    public void OnClickHomeButton()
    {
        SceneManager.LoadScene("Title");
    }

    public int audioIndex;
    // �뷡 ���� ��ư
    public void OnClickAudioSelectButton(int n)
    {
        audioIndex = n;
        Debug.Log("AudioSource " + n + " selected");        
        AudioButtons.SetActive(false);
        playMusicArea.SetActive(true);
        OnInstrumentSelection();
    }

    // ���� Close Button
    public void OnClickCloseButton()
    {
        OffInstrumentSelection();
        AudioButtons.SetActive(true);
        playMusicArea.SetActive(false);
    }
    // �Ǳ� ���� UI
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
