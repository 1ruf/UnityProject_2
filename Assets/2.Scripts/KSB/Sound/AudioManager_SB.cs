using UnityEngine;
using UnityEngine.Audio;

public class AudioManager_SB : MonoBehaviour
{

    [Header("AudioMixer")]
    [SerializeField] private AudioMixer _bgm;

    public void BGM_Volume(float value)
    {
        if (_bgm == null)
            print("����");
        else
            print("�� �ٱ�");
            _bgm.SetFloat("BGM", value * 10);
    }

    public void SFX_Volume(float value)
    {
        if (_bgm == null)
            print("����");
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
