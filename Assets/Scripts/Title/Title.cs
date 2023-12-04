using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    [SerializeField] RectTransform[] rectTransforms;
    [SerializeField] RectTransform[] animPositions;
    [SerializeField] CanvasGroup[] fades;

    public void OnClickStartKorean()
    {
        TitleOut();
        LanguageID.selectLanguage = 0;
        StartCoroutine("StartMain");
    }
    public void OnClickStartEnglish()
    {
        TitleOut();
        LanguageID.selectLanguage = 1;
        StartCoroutine("StartMain");
    }
    

    void TitleOut()
    {
        for (int i = 0; i < rectTransforms.Length; i++)
        {
            rectTransforms[i].DOAnchorPos(animPositions[i].anchoredPosition, 1.0f);
        }
        for (int i = 0; i < fades.Length; i++)
        {
            fades[i].DOFade(0, 1.0f);
        }
    }

    IEnumerator StartMain()
    {
        yield return new WaitForSecondsRealtime(2f);
        SceneManager.LoadScene("MainScene");
    }

}
