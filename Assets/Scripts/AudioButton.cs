using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioButton : MonoBehaviour
{
    [SerializeField] RectTransform initialPosition;
    [SerializeField] RectTransform animPosition;

    private RectTransform rectTransform;
    private bool isSelectable;

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
    }
    public void HideButton()
    {
        rectTransform.DOAnchorPos(initialPosition.anchoredPosition, 1.0f);
    }
}
