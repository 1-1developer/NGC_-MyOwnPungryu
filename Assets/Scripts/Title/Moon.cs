using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Moon : MonoBehaviour
{
    [SerializeField] RectTransform initialPosition;
    [SerializeField] RectTransform animPosition;
    [SerializeField] RectTransform ciricle;
    [SerializeField] RectTransform[] ciricles;
    [SerializeField] RectTransform[] Stars;

    private RectTransform rectTransform;
    private bool isSelectable;

    Tween fadeTween;

    float x;
    float y;
    float timer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        x = Mathf.Cos(timer);
        y = Mathf.Sin(timer);
        loopMoon();
    }

    void loopMoon()
    {
        ciricle.DORotate(new Vector3(0, 0, 360), 25.5f, RotateMode.LocalAxisAdd)
                     .SetLoops(-1,LoopType.Restart);
        //foreach (RectTransform r in ciricles)
        //{
        //    r.DOAnchorPos(new Vector2(x,y),1f).SetLoops(-1, LoopType.Restart);
        //}
        //foreach (RectTransform s in Stars)
        //{
        //    s.GetComponent<Material>().DOFade(0,.3f).SetLoops(-1, LoopType.Yoyo);
        //}
    }
}
