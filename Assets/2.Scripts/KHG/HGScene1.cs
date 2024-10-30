using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using URPGlitch.Runtime.AnalogGlitch;
using URPGlitch.Runtime.DigitalGlitch;

public class HGScene1 : MonoBehaviour
{
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
}
