using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    private Scrollbar _slider;
    [SerializeField] private float _maxValue;
    private float _currentValue;


    private void Start()
    {
        _slider = GetComponent<Scrollbar>();
        _slider.size = 1;
        _currentValue = _maxValue;
    }

    private void Update()
    {
        if (_maxValue <= 0) return;
        BarScrollChange(_currentValue/_maxValue);
    }

    private void BarScrollChange(float value)
    {
        _slider.size = Mathf.Lerp(_slider.size, value, Time.deltaTime*10);
    }

    public void BarValueChange(float value)
    {
        _currentValue += value;
    }
}
