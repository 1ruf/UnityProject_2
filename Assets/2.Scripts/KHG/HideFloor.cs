using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class HideFloor : MonoBehaviour
{
    [SerializeField] private Transform _detectionArea;
    [SerializeField] private float _fadeDuration = 1f;

    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _spriteRenderer.DOFade(0f, _fadeDuration).SetEase(Ease.OutQuart);
        }
    }
}
