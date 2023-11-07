using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneUI : MonoBehaviour
{
    [SerializeField]
    private RectTransform shelfLeftTransform;
    [SerializeField]
    private RectTransform shelfRIghtTransform;

    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void OnClickHomeButton()
    {
        SceneManager.LoadScene("Title");
    }
    public void OnClickAudioSelectButton(int n)
    {
        Debug.Log("AudioSource " + n + " selected");
        OnInstrumentSelection();
    }

    float shelfMoveRange = 150.0f;
    float shelfMoveSpeed = 5.0f;
    public void OnInstrumentSelection()
    {
        float shelfMovement =+ Time.deltaTime * shelfMoveSpeed;
                 
        shelfLeftTransform.anchoredPosition = new Vector2(shelfMoveRange, 0);
        shelfRIghtTransform.anchoredPosition = new Vector2(-shelfMoveRange, 0);
    }
    public void OffInstrumentSelection()
    {        
        shelfLeftTransform.anchoredPosition = new Vector2(-shelfMoveRange, 0);
        shelfRIghtTransform.anchoredPosition = new Vector2(shelfMoveRange, 0);
    }
}
