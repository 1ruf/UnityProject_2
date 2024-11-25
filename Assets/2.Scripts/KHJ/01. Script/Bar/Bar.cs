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

    [SerializeField] private Transform _energyBar, _hpbar;
    [SerializeField] private Image _subHandle;
    [SerializeField] private float energyChargeSpeed;
    private Image _energySlider, _hpSlider;
    private bool _charging;
    private int _changeTime;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this);
    }

    private void Start()
    {
        _energySlider = _energyBar.GetComponent<Image>();
        _hpSlider = _hpbar.GetComponent<Image>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            BarValueChange(BarSliderType.Energy,-5f, 100);
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            BarValueChange(BarSliderType.Hp, -5f, 100);
        }
    }

    private void CheckCharge()
    {
        if (_charging == false)
        {
            StartCoroutine(EnegyCharge());
            _charging = true;
        }
    }

    private IEnumerator EnegyCharge()
    {
        while (true)
        { 
            if (_energySlider.fillAmount >= 1) break;                
            yield return new WaitForSeconds(0.05f);
            _energySlider.fillAmount += (0.01f * energyChargeSpeed);                 
        }
        _charging = false;
    }
    private void BarScrollChange(BarSliderType slider, float value, float maxCharge)
    {
        switch (slider)
        {
            case BarSliderType.Energy:
                _energySlider.fillAmount += value / maxCharge;
                break;
            case BarSliderType.Hp:
                _hpSlider.fillAmount += value / maxCharge;
                break;
        }
        print("값추가된");
        CheckCharge();
    }

    public void BarValueChange(BarSliderType slider, float value, float maxCharge) //호출해야되는거
    {
        BarScrollChange(slider,value, maxCharge);
        _changeTime = 1;
        StartCoroutine(CheckValueChange());
    }

    private IEnumerator CheckValueChange()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(1f);
            _changeTime++;
        }
        if (_changeTime == 10)
        {
            _subHandle.DOFillAmount(_energySlider.fillAmount,0.5f);
        }
    }
}
public enum BarSliderType
{
    Hp,
    Energy
}
