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

    private RectTransform initial_shelfLeftTransform;
    private RectTransform initial_shelfrightTransform;
    void Start()
    {
        initial_shelfLeftTransform = shelfLeftTransform;
        initial_shelfrightTransform = shelfRIghtTransform;
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
        OnInstrumentSelection();
    }
    public void OnInstrumentSelection()
    {
        shelfLeftTransform.DOAnchorPosX(-810.0f, 1.0f);
        shelfRIghtTransform.DOAnchorPosX(810.0f, 1.0f);
    }
    public void OffInstrumentSelection()
    {
        shelfLeftTransform.DOAnchorPosX(initial_shelfLeftTransform.anchoredPosition.x, 1.0f);
        shelfRIghtTransform.DOAnchorPosX(initial_shelfrightTransform.anchoredPosition.x, 1.0f);
    }
}
