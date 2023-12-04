using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LanguageMode : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI[] guidetxts;
    [SerializeField] TextMeshProUGUI[] instrumenttxts;
    [SerializeField] Sprite[] s_songs;
    [SerializeField] Image[] i_songs;
    [SerializeField] Image goback;
    [SerializeField] Sprite[] gobacks;
    [SerializeField] Image guideM;
    [SerializeField] Sprite[] guideMs;


    string[] guideK = { "원하는 곡을 선택해주세요!",
        "밤 하늘에 악기를 띄워 나만의 풍류 음악을 완성해보세요!",
         };

    string[] guideE = { "Please select the song you want!",
        "Float instruments in the night sky to complete your own musical style!",
        };

    string[] insK = { "대금", "해금", "가야금", "피리", "장구", "거문고" };
    string[] insE = { "Daegeum", "Haegeum", "Gayageum", "Piri", "Janggu", "Geomungo" };

    void Start()
    {
        if(LanguageID.selectLanguage == 0)//korean
        {
            for (int i = 0; i < guidetxts.Length; i++)
            {
                guidetxts[i].text = guideK[i];
            }
            for (int i = 0; i < instrumenttxts.Length; i++)
            {
                instrumenttxts[i].text = insK[i];
            }
            for (int i = 0; i < i_songs.Length; i++)
            {
                i_songs[i].sprite = s_songs[i];
            }
            goback.sprite = gobacks[0];
            guideM.sprite = guideMs[0];
        }
        else
        {
            for (int i = 0; i < guidetxts.Length; i++)
            {
                guidetxts[i].text = guideE[i];
            }
            for (int i = 0; i < instrumenttxts.Length; i++)
            {
                instrumenttxts[i].text = insE[i];
            }
            for (int i = 0; i < i_songs.Length; i++)
            {
                i_songs[i].sprite = s_songs[i+3];
            }
            goback.sprite = gobacks[1];
            guideM.sprite = guideMs[1];

        }
    }
}
