using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
        }


    }
    [Header("Audio Manager")]
    [SerializeField] private AudioMixer _mixer;
    [SerializeField] private AudioSource _Source;

    public void SetMasterVolume(float sliderValue)
    {
        _mixer.SetFloat("MasterValume", Mathf.Log10(sliderValue) * 20);
    }
    public void SetMusicVolume(float sliderValue)
    {
        _mixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);
    }
    public void SetSFXVolume(float sliderValue)
    {
        _mixer.SetFloat("SFXVolume", Mathf.Log10(sliderValue) * 20);
    }

    public void PlayAudio(AudioClip clip)
    {
        if (_Source.clip == clip) return;
        _Source.Stop();
        _Source.clip = clip;
        _Source.Play();

    }
}
