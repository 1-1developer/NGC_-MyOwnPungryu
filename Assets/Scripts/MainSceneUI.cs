using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MainSceneUI : MonoBehaviour
{
    [SerializeField]
    private RectTransform shelfLeftTransform;
    [SerializeField]
    private RectTransform shelfRIghtTransform;
    [SerializeField]
    private GameObject AudioButtons;
    [SerializeField]
    private GameObject playMusicArea;

    private Vector2 initial_shelfLeftTransform;
    private Vector2 initial_shelfrightTransform;
    void Start()
    {
        initial_shelfLeftTransform = shelfLeftTransform.anchoredPosition;
        initial_shelfrightTransform = shelfRIghtTransform.anchoredPosition;
        playMusicArea.SetActive(false);
    }
    void Update()
    {
        
    }
    public void OnClickHomeButton()
    {
        SceneManager.LoadScene("Title");
    }
    public void OnClickAudioSelectButton(int n)
    {
        Debug.Log("AudioSource " + n + " selected");
        AudioButtons.SetActive(false);
        playMusicArea.SetActive(true);
        OnInstrumentSelection();
    }
    public void OnClickCloseButton()
    {
        OffInstrumentSelection();
        AudioButtons.SetActive(true);
        playMusicArea.SetActive(false);
    }
    public void OnInstrumentSelection()
    {
        float moveRange = 200.0f;
        shelfLeftTransform.DOAnchorPosX(initial_shelfLeftTransform.x + moveRange, 1.0f);
        shelfRIghtTransform.DOAnchorPosX(initial_shelfrightTransform.x - moveRange, 1.0f);
    }
    public void OffInstrumentSelection()
    {
        shelfLeftTransform.DOAnchorPosX(initial_shelfLeftTransform.x, 1.0f);
        shelfRIghtTransform.DOAnchorPosX(initial_shelfrightTransform.x, 1.0f);
    }
}
