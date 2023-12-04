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


    string[] guideK = { "���ϴ� ���� �������ּ���!",
        "�� �ϴÿ� �Ǳ⸦ ��� ������ ǳ�� ������ �ϼ��غ�����!",
         };

    string[] guideE = { "Please select the song you want!",
        "Float instruments in the night sky to complete your own musical style!",
        };

    string[] insK = { "���", "�ر�", "���߱�", "�Ǹ�", "�屸", "�Ź���" };
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
