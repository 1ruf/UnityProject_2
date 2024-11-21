using UnityEngine;

public class AudioManager_SB : MonoBehaviour
{
    public AudioClip[] bgmSounds, sfxSounds;
    public AudioSource bgmSource, sfxSource;
    private static AudioManager_SB _instance;

    public static AudioManager_SB Instance
    {
        get
        {
            if (_instance == null)
            {
               
                GameObject audioManager = new GameObject("AudioManager_SB");
                _instance = audioManager.AddComponent<AudioManager_SB>();
                DontDestroyOnLoad(audioManager);  
            }
            return _instance;
        }
    }

    private void Start()
    {
        PlayBgm(BGMSoundtype.noraml1);
    }
    public void PlayBgm(BGMSoundtype sound)
    {
        AudioClip targetClip;

        switch (sound)
        {
            case BGMSoundtype.noraml1:
                targetClip = bgmSounds[0];
                break;
            case BGMSoundtype.noraml2:
                targetClip = bgmSounds[1];
                break;
            case BGMSoundtype.Death:
                targetClip = bgmSounds[2];
                break;
            case BGMSoundtype.decisive:
                targetClip = bgmSounds[3];
                break;
            default:
                targetClip = bgmSounds[0];
                break;

        }

        bgmSource.clip = targetClip;
        bgmSource.loop = true;
        bgmSource.Play();
    }

    public void PlaySfx(SFXSoundtype sound)
    {
        AudioClip targetClip;

        switch (sound)
        {
            case SFXSoundtype.idle:
                targetClip = bgmSounds[0];
                break;
            case SFXSoundtype.move:
                targetClip = sfxSounds[1];
                break;
            case SFXSoundtype.death:
                targetClip = sfxSounds[2];
                break;
            default:
                targetClip = sfxSounds[0];
                break;


        }

        sfxSource.clip = targetClip;
        sfxSource.Play();
    }

    public void BGM_Volume(float value)
    {
        if (bgmSource == null)
            print("1");
        bgmSource.volume = value;
    }

    public void SFX_Volume(float value)
    {
        sfxSource.volume = value;
    }

    public void BGMToggle()//button
    {
       bgmSource.mute = bgmSource.mute;//mute 음소거/버튼
    }

    public void SFXToggle()//button
    {
        sfxSource.mute = !sfxSource.mute;//mute 음소거/버튼

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
