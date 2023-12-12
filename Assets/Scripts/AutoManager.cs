using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AutoManager : MonoBehaviour
{
    static int PlayCount = 0;
    void Start()
    {
        // 현재 활성화된 씬의 정보를 얻습니다.
        Scene currentScene = SceneManager.GetActiveScene();
        if(PlayCount == 0)
        {
            if (currentScene.name == "Title")
            {
                Title title = FindFirstObjectByType<Title>();
                title.OnClickStartKorean();
            }
            else if (currentScene.name == "MainScene")
            {
                MainSceneUI mainSceneUI = FindFirstObjectByType<MainSceneUI>();
                mainSceneUI.OnClickAudioSelectButton(0);
                DragDropButtons dd = FindFirstObjectByType<DragDropButtons>();
                dd.autoInit();
                mainSceneUI.OnClickHomeButton();
                PlayCount++;
            }
        }
    }
}
