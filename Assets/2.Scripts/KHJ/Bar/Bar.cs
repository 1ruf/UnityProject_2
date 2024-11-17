using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class Bar : MonoBehaviour
{
    [SerializeField] private int energyChargeSpeed;
    [SerializeField] private Transform _bar;
    private Image _slider;
    private bool _charging;
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
            _slider.fillAmount += 0.01f;                 
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
    }
}
