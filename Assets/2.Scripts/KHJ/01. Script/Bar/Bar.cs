using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class Bar : MonoBehaviour
{
    [SerializeField] private Transform _bar;
    [SerializeField] private Image _subHandle;
    [SerializeField] private float energyChargeSpeed;
    private Image _slider;
    private bool _charging;
    private int _changeTime;
    public int _maxCharge { get; private set; } = 100;


    private void Start()
    {
        _slider = _bar.GetComponent<Image>();
    }

    private void Update()
    {
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
            if (_slider.fillAmount >= 1) break;                
            yield return new WaitForSeconds(0.05f);
            _slider.fillAmount += (0.01f * energyChargeSpeed);                 
        }
        _charging = false;
    }
    private void BarScrollChange(float value)
    {
        _slider.fillAmount += value / _maxCharge;
        CheckCharge();
    }

    public void BarValueChange(float value)
    {
        BarScrollChange(value);
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
            _subHandle.DOFillAmount(_slider.fillAmount,0.5f);
        }
    }
}
