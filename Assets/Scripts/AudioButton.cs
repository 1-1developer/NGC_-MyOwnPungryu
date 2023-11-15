using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioButton : MonoBehaviour
{
    [SerializeField] RectTransform audioButtonInitialPosition;
    // Start is called before the first frame update
    void Start()
    {
        RectTransform currentPosition = GetComponent<RectTransform>();
        RectTransform destination = currentPosition;

        currentPosition = audioButtonInitialPosition;

        //currentPosition.DOAnchorPos(new Vector2(destination.anchoredPosition.x, destination.anchoredPosition.y), 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
