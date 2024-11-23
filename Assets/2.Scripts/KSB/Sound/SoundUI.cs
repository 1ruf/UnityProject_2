using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundUI : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider bgmSlider;
    [SerializeField] private Slider sfxSlider;

    void Start()
    {
        bgmSlider.onValueChanged.AddListener(SetBGMVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);

        if (SaveManager.Instance.GetData<string>((int)Datas.FirstEnter) == "0")
        {
            bgmSlider.value = 0.75f;
            sfxSlider.value = 0.75f;
        }
        else
        {
            bgmSlider.value = SaveManager.Instance.GetData<float>((int)Datas.Setting_BGM);
            sfxSlider.value = SaveManager.Instance.GetData<float>((int)Datas.Setting_SFX);
        }
    }

    public void SetBGMVolume(float volume)
    {
        // AudioMixer의 볼륨을 조정
        audioMixer.SetFloat("BGMVolume", Mathf.Log10(volume) * 20); 
        SaveManager.Instance.SetDataString((int)Datas.Setting_BGM,volume.ToString());
    }

    public void SetSFXVolume(float volume)
    {
        // AudioMixer의 볼륨을 조정
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);
        SaveManager.Instance.SetDataString((int)Datas.Setting_SFX, volume.ToString());
    }
}
