using UnityEngine;
using UnityEngine.Audio;

public class AudioManager_SB : MonoBehaviour
{

    [Header("AudioMixer")]
    [SerializeField] private AudioMixer _bgm;

    public void BGM_Volume(float value)
    {
        if (_bgm == null)
            print("없음");
        else
            print("값 바귐");
            _bgm.SetFloat("BGM", value * 10);
    }

    public void SFX_Volume(float value)
    {
        if (_bgm == null)
            print("없음");
        _bgm.SetFloat("SFX", value * 10);
    }

    public void BGMToggle()
    {
        _bgm.SetFloat("BGM", 0f);
    }

    public void SFXToggle()
    {
        _bgm.SetFloat("SFX", 0f); ;
    }
}
