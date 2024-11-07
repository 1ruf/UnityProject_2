using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MenuBGMManager : MonoBehaviour
{
    [SerializeField] private AudioClip _audioClip;

    public AudioSource _audio { get; set; }
    [Header("setting")]
    [SerializeField] private bool playOnEnabled;
    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }
    private void OnEnable()
    {
        _audio.clip = _audioClip;
        _audio.pitch = 0;
        if (playOnEnabled == true)
        {
            PlayBGMWithPitch(_audio,0.9f, 1.5f, true);
        }
    }
    public void SetBGM(AudioSource audio,bool play)
    {
        if (play == true)
        {
            audio.Play();
        }
        else
        {
            audio.Pause();
        }
        
    }
    public void SetVolume(AudioSource audio, float targetValue, float time)
    {
        audio.DOFade(targetValue, time);
    }
    public void PlayBGMWithPitch(AudioSource audio,float pitch,float time,bool play)
    {
        if (play == true)
        {
            audio.DOPitch(pitch, time);
            audio.Play();
        }
        else
        {
            audio.DOPitch(0, time);
            audio.Play();
        }
    }
}
