using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    Image image;
    [SerializeField] GameObject touchIcon;
    [SerializeField] Vector2 touchIconAnimPosition;

    private void Start()
    {
        image = GetComponent<Image>();
        image.DOFade(1.1f, 0.8f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
        touchIcon.GetComponent<RectTransform>().DOAnchorPos(touchIconAnimPosition, 2.0f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    { 
        gameObject.SetActive(false);
    }

}
