using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class HideFloor : MonoBehaviour
{
    [SerializeField] private Transform _detectionArea;
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private float _fadeDuration = 1f;

    private SpriteRenderer _spriteRenderer;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Collider2D collision = Physics2D.OverlapBox(_detectionArea.position, _detectionArea.localScale, 0f, _playerLayer);

        if (collision != null)
        {
            if (_spriteRenderer != null)
            {
                _spriteRenderer.DOFade(0f, _fadeDuration).SetEase(Ease.OutQuart);
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (_detectionArea != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(_detectionArea.position, _detectionArea.localScale);
        }
    }
}
