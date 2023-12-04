using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource[] instrumentAudio;
    [SerializeField] AudioClip[] audioClips1;
    [SerializeField] AudioClip[] audioClips2;
    [SerializeField] AudioClip[] audioClips3;

    public static bool isMusicStarted = false;

    public void SetAudioClips(int index)
    {
        if(index == 0)
        {
            for (int i = 0; i < instrumentAudio.Length; i++)
            {
                instrumentAudio[i].clip = audioClips1[i];
            }
        }
        if (index == 1)
        {
            for (int i = 0; i < instrumentAudio.Length; i++)
            {
                instrumentAudio[i].clip = audioClips2[i];
            }
        }
        if (index == 2)
        {
            for (int i = 0; i < instrumentAudio.Length; i++)
            {
                instrumentAudio[i].clip = audioClips3[i];
            }
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
