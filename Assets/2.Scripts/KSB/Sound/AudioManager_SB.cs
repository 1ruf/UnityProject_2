using UnityEngine;
using UnityEngine.Audio;

public class AudioManager_SB : MonoBehaviour
{
    public static AudioManager_SB Instance { get; private set; }

    public AudioClip[] bgmSounds, sfxSounds;
    public AudioSource bgmSource, sfxSource;

    [Header("AudioMixer")]
    [SerializeField] private AudioMixer _bgm;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        ChangeBGM(BGMSoundtype.noraml1);
        bgmSource.Play();
        sfxSource.clip = sfxSounds[0];
        sfxSource.Play();
    }

    public void BGM_Volume(float value)
    {
        if (_bgm == null)
            print("없음");
        else
            _bgm.SetFloat("BGM", Mathf.Log10(value) * 20);
    }

    public void SFX_Volume(float value)
    {
        if (_bgm == null)
            print("없음");
        _bgm.SetFloat("SFX", Mathf.Log10(value) * 20);
    }

    public void BGMToggle()
    {
        bgmSource.mute = !bgmSource.mute;
    }

    public void SFXToggle()
    {
        sfxSource.mute = !sfxSource.mute;
    }

    public void ChangeBGM(BGMSoundtype sound)
    {
        switch (sound)
        {
            case BGMSoundtype.noraml1:
                bgmSource.clip = bgmSounds[0];
                break;
            case BGMSoundtype.noraml2:
                bgmSource.clip = bgmSounds[1];
                break;
            case BGMSoundtype.Death:
                bgmSource.clip = bgmSounds[2];
                break;
            case BGMSoundtype.decisive:
                bgmSource.clip = bgmSounds[3];
                break;
        }
        bgmSource.Play();
    }
}

public enum BGMSoundtype
{
    noraml1,
    noraml2,
    Death,
    decisive
}

public enum SFXSoundtype
{
    idle,
    move,
    death,
}
