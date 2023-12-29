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

    public void OnClickStartKorean() //����� - �ѱ���
    {
        TitleOut(); //Ʈ������ ���
        LanguageID.selectLanguage = 0;
        AudioManager.PlayDefaultButtonSound();
        StartCoroutine("StartMain");
    }
    public void OnClickStartEnglish()//����� - ����
    {
        TitleOut();//Ʈ������ ���
        LanguageID.selectLanguage = 1;
        AudioManager.PlayDefaultButtonSound();
        StartCoroutine(StartMain());
    }
    private void Start()
    {
        DOTween.Init();//��Ʈ�� �ʱ�ȭ
        loadingText.GetComponent<CanvasGroup>().DOFade(0, .001f);

        //UI��� ��ġ �ʱ�ȭ
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

    void TitleOut()//Ÿ��Ʋ �ƿ� Ʈ������ 
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

    IEnumerator StartMain()//�ε����
    {
        if (LanguageID.selectLanguage == 0)
        {
            loadingText.text = "�ε� ��... ";
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

            //// �ε� ���� ��Ȳ�� ���� UI ���� (�ε� �� ���)
            //if (loadingSlider != null)
            //    loadingSlider.value = Mathf.Clamp01(asyncLoad.progress / 0.9f);

            // �ε� �޽��� ���� �� �پ��� ������Ʈ �۾��� ������ �� �ֽ��ϴ�.
            if (loadingText != null)
            {
                if (LanguageID.selectLanguage == 0)
                {
                    loadingText.text = "�ε� ��... " + (asyncLoad.progress * 100f).ToString("F0") + "%";
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
