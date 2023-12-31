using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioButton : MonoBehaviour
{
    [SerializeField] RectTransform initialPosition; //초기 위치값
    [SerializeField] RectTransform animPosition; //모션적용시 위치값

    private RectTransform rectTransform; //자기자신
    private bool isSelectable;
    [SerializeField] GameObject selecttext;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        rectTransform.anchoredPosition = initialPosition.anchoredPosition;
        isSelectable = true;
        ShowButton();
    }
    private void Update()
    {
        if (MainSceneUI.Instance.isShelfOn && isSelectable)
        {
            HideButton();
            isSelectable = false;
        }
        else if(!MainSceneUI.Instance.isShelfOn && !isSelectable)
        {
            ShowButton();
            isSelectable = true;
        }
    }
    public void ShowButton()
    {
        rectTransform.DOAnchorPos(animPosition.anchoredPosition, 1.0f);
        selecttext.SetActive(true);
    }
    public void HideButton()
    {
        rectTransform.DOAnchorPos(initialPosition.anchoredPosition, 1.0f);
        selecttext.SetActive(false);
    }
}
