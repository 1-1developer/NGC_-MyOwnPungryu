using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    [SerializeField] RectTransform[] rectTransforms;
    [SerializeField] RectTransform[] animPositions;
    [SerializeField] CanvasGroup[] fades;

    [SerializeField] GameObject[] shadows;
    [SerializeField] GameObject[] anim;

    [SerializeField] RectTransform[] originPos;

    //public Slider loadingSlider;
    public TextMeshProUGUI loadingText;

    public void OnClickStartKorean() //언어모드 - 한국어
    {
        TitleOut(); //트랜지션 재생
        LanguageID.selectLanguage = 0;
        AudioManager.PlayDefaultButtonSound();
        StartCoroutine("StartMain");
    }
    public void OnClickStartEnglish()//언어모드 - 영어
    {
        TitleOut();//트랜지션 재생
        LanguageID.selectLanguage = 1;
        AudioManager.PlayDefaultButtonSound();
        StartCoroutine(StartMain());
    }
    private void Start()
    {
        DOTween.Init();//닷트윈 초기화
        loadingText.GetComponent<CanvasGroup>().DOFade(0, .001f);

        //UI요소 위치 초기화
        for (int i = 0; i < rectTransforms.Length; i++) 
        {
            //originPos[i].anchoredPosition = rectTransforms[i].anchoredPosition;
            rectTransforms[i].anchoredPosition = animPositions[i].anchoredPosition;
        }
        for (int i = 0; i < rectTransforms.Length; i++)
        {
            rectTransforms[i].DOAnchorPos(originPos[i].anchoredPosition, 1.0f);
        }
    }

    void TitleOut()//타이틀 아웃 트랜지션 
    {
        for (int i = 0; i < rectTransforms.Length; i++)
        {
            rectTransforms[i].DOAnchorPos(animPositions[i].anchoredPosition, 1.0f);
        }
        for (int i = 0; i < fades.Length; i++)
        {
            fades[i].DOFade(0, 1.0f);
        }
        rectTransforms[0].GetComponent<CanvasGroup>().DOFade(0.06f, 1.0f);
    }

    IEnumerator StartMain()//로딩기능
    {
        if (LanguageID.selectLanguage == 0)
        {
            loadingText.text = "로딩 중... ";
        }
        else
        {
            loadingText.text = "Loading... ";
        }
        loadingText.GetComponent<CanvasGroup>().DOFade(1, .5f);
       yield return new WaitForSecondsRealtime(.9f);

        //SceneManager.LoadScene("MainScene");

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("MainScene");

        while (!asyncLoad.isDone)
        {

            //// 로딩 진행 상황에 따라 UI 갱신 (로딩 바 사용)
            //if (loadingSlider != null)
            //    loadingSlider.value = Mathf.Clamp01(asyncLoad.progress / 0.9f);

            // 로딩 메시지 갱신 등 다양한 업데이트 작업을 수행할 수 있습니다.
            if (loadingText != null)
            {
                if (LanguageID.selectLanguage == 0)
                {
                    loadingText.text = "로딩 중... " + (asyncLoad.progress * 100f).ToString("F0") + "%";
                }
                else
                {
                    loadingText.text = "Loading... " + (asyncLoad.progress * 100f).ToString("F0") + "%";
                }
            }

            yield return null;
        }
    }
}
