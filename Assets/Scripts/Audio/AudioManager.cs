using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] GameObject[] instrumentButtons;
    [SerializeField] AudioSource[] instrumentAudio;

    public static bool isMusicStarted = false;
    //private AudioClip[] audioClips;

    void Awake()
    {

    }

    public void SetAudioClips(int index)
    {
        for(int i = 0; i < instrumentAudio.Length; i++)
        {
            instrumentAudio[i].clip = instrumentButtons[i].GetComponent<DragDropButtons>().audioClips[index];
        }
    }

    public void StopAudioSources()
    {
        for (int i = 0; i < instrumentAudio.Length; i++)
        {
            instrumentAudio[i].Stop();
        }
    }

    // Singleton
    private static AudioManager _Instance;
    public static AudioManager Instance
    {
        get
        {
            if (_Instance == null)
            {
                _Instance = FindAnyObjectByType<AudioManager>();
            }
            return _Instance;
        }
    }
}
