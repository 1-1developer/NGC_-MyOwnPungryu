using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public static int selectLanguage;
    public void OnClickStartKorean()
    {
        selectLanguage = 0;
        SceneManager.LoadScene("MainScene");
    }
    public void OnClickStartEnglish()
    {
        selectLanguage = 1;
        SceneManager.LoadScene("MainScene");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
