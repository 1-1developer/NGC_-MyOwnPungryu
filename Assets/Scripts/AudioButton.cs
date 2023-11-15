using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioButton : MonoBehaviour
{
    [SerializeField] RectTransform initialPosition;
    [SerializeField] RectTransform animPosition;

    private RectTransform rectTransform;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        rectTransform.anchoredPosition = initialPosition.anchoredPosition;

        ShowButton();
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
