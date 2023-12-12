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


    [Header("UI Sounds")]
    [Tooltip("General button click.")]
    [SerializeField] AudioClip m_DefaultButtonSound;

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
    public static void PlayDefaultButtonSound()
    {
        AudioManager audioManager = FindFirstObjectByType<AudioManager>();
        if (audioManager == null)
            return;

        PlayOneSFX(audioManager.m_DefaultButtonSound, Vector3.zero);
    }

    public static void PlayOneSFX(AudioClip clip, Vector3 sfxPosition)
    {
        if (clip == null)
            return;

        GameObject sfxInstance = GameObject.Find(clip.name);
        if (sfxInstance != null)
            return;
        sfxInstance = new GameObject(clip.name);
        sfxInstance.transform.position = sfxPosition;

        AudioSource source = sfxInstance.AddComponent<AudioSource>();
        source.volume = .3f;
        source.clip = clip;
        source.Play();

        // destroy after clip length
        Destroy(sfxInstance, clip.length);
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
