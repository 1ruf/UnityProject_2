using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using URPGlitch.Runtime.AnalogGlitch;
using URPGlitch.Runtime.DigitalGlitch;

public class HGScene1 : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverUI;

    [SerializeField] private Volume _volume;
    private DigitalGlitchVolume _digitalGt;
    private AnalogGlitchVolume _analogGt;   
    private void OnEnable()
    {
        StartCoroutine(FadeOut());
    }
    private IEnumerator FadeOut()
    {
        DigitalGlitchVolume _digitalGlitch;
        AnalogGlitchVolume _analogGlitch;
        if (_volume.profile.TryGet<DigitalGlitchVolume>(out _digitalGlitch))
        {
            _volume.profile.TryGet<AnalogGlitchVolume>(out _analogGlitch);
            _digitalGt = _digitalGlitch;
            _analogGt = _analogGlitch;
            float value = 1.0f;
            while (true)
            {
                if (_digitalGt.intensity.value <= 0)
                {
                    break;
                }
                value -= 0.05f;
                _analogGt.scanLineJitter.value = value;
                _digitalGt.intensity.value = value;
                yield return new WaitForSeconds(0.05f);
            }
        }
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            DamagedScreen(0.2f);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameOver();
        }
    }


    private IEnumerator Damaged(float amount)
    {
        AnalogGlitchVolume _analogGlitch;
        if (_volume.profile.TryGet<AnalogGlitchVolume>(out _analogGlitch))
        {
            _analogGt = _analogGlitch;
            float value = amount;
            //float vigValue = 2 * amount / 3;
            _analogGlitch.colorDrift.value = value;
            while (true)
            {
                value -= 0.01f;
                _analogGlitch.colorDrift.value = value;
                if (_analogGlitch.colorDrift.value <= 0)
                {
                    break;
                }
                yield return new WaitForSeconds(0.01f);
            }
        }
    }

    private IEnumerator GameOverScreen()
    {
        AnalogGlitchVolume _analogGlitch;
        if (_volume.profile.TryGet<AnalogGlitchVolume>(out _analogGlitch))
        {
            _analogGt = _analogGlitch;
            float value = 0.5f;
            _analogGlitch.colorDrift.value = value;
            while (true)
            {
                value += 0.01f;
                _analogGlitch.colorDrift.value = value;
                //_analogGlitch.verticalJump.value = value;
                _analogGlitch.horizontalShake.value = value;
                _analogGlitch.scanLineJitter.value = value;
                if (_analogGlitch.colorDrift.value >= 1)
                {
                    break;
                }
                yield return new WaitForSeconds(0.01f);
            }
            _gameOverUI.SetActive(true);
        }
    }



    public void DamagedScreen(float amount)
    {
        StartCoroutine(Damaged(amount));
    }


    public void GameOver()
    {
        StartCoroutine(GameOverScreen());
    }
}



//DigitalGlitchVolume _digitalGlitch;
//AnalogGlitchVolume _analogGlitch;
//if (_volume.profile.TryGet<DigitalGlitchVolume>(out _digitalGlitch))
//{
//    _volume.profile.TryGet<AnalogGlitchVolume>(out _analogGlitch);
//    _digitalGt = _digitalGlitch;
//    _analogGt = _analogGlitch;
//    float value = 1.0f;
//    while (true)
//    {
//        if (_digitalGt.intensity.value <= 0)
//        {
//            break;
//        }
//        value -= 0.05f;
//        _analogGt.scanLineJitter.value = value;
//        _digitalGt.intensity.value = value;
//        yield return new WaitForSeconds(0.05f);
//    }
//}