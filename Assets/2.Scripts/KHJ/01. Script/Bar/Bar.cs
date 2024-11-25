using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.InputSystem;
using System;

public class Bar : MonoBehaviour
{
    static public Bar Instance;


    private float _energyChargeSpeed = 4;
    [SerializeField] private Image _energySlider, _hpSlider;

    private float _energyValue;
    private float _hpValue;


    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this);
    }



    private void Update()
    {
        _energySlider.fillAmount = Mathf.Lerp(_energySlider.fillAmount, _energyValue, Time.deltaTime * _energyChargeSpeed);
        _hpSlider.fillAmount = Mathf.Lerp(_hpSlider.fillAmount, _hpValue, Time.deltaTime * _energyChargeSpeed);
    }


    public void BarValueChange(BarSliderType slider, float value, float maxCharge)
    {
        switch (slider)
        {
            case BarSliderType.Energy:
                _energyValue = value / maxCharge;
                break;
            case BarSliderType.Hp:
                _hpValue = value / maxCharge;
                break;
        }
    }
}
public enum BarSliderType
{
    Hp,
    Energy
}
