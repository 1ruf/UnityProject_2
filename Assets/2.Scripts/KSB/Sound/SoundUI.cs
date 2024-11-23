using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundUI : MonoBehaviour
{
    [SerializeField] private Slider bgmSlider;
    [SerializeField] private Slider sfxSlider;
    private AudioManager_SB _audioMan;
    private void Awake()
    {
        _audioMan = AudioManager_SB.Instance;
    }

    private void Update()
    {
        SetBGMVolume();
        SetSFXVolume();
    }
    private void SetBGMVolume()
    {
        _audioMan.bgmSource.volume = bgmSlider.value;

    }

    private void SetSFXVolume()
    {
        _audioMan.sfxSource.volume = sfxSlider.value;
    }
    public void BGMMute()
    {
        _audioMan.BGMToggle();
    }

    public void SFXMute()
    {
        _audioMan.SFXToggle();
    }
}
