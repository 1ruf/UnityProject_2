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
    private void Start()
    {
      
        if (_audioMan == null)
        {
            print("¾øÀ½");
        }
    }
    private void Update()
    {
        SetVolume();
    }
  
    public void BGMMuteButton()
    {
        _audioMan.BGMToggle();
    }

    public void SFXMuteButton()
    {
        _audioMan.SFXToggle();
    }
    private void SetVolume()
    {
        _audioMan.BGM_Volume(bgmSlider.value);
        _audioMan.SFX_Volume(sfxSlider.value);
    }
}
