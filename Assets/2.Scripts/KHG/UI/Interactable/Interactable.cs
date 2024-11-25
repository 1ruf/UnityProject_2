using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class Interactable : MonoBehaviour
{
    [SerializeField] private float interactionRadius = 3f; // 감지 범위
    [SerializeField] private LayerMask interactableLayer; // 상호작용 가능한 레이어 설정
    [SerializeField] private Image[] _InteractUI; // 상호작용 UI
    [SerializeField] private TextMeshProUGUI[] _InteractUI_TMP; // 상호작용 UI
    private Collider[] _overlapResults = new Collider[10]; // OverlapSphere 결과 저장
    private bool _isInRange = false; // 상호작용 범위 내 있는지 확인

    public UnityEvent OnInteracted;

    private void Update()
    {
        CheckForInteractable();
        HandleInput();
    }

    // OverlapSphere를 사용해 상호작용 가능한 오브젝트 탐지
    private void CheckForInteractable()
    {
        Collider2D plr = Physics2D.OverlapCircle(transform.position, interactionRadius,interactableLayer);

        if (plr != null)
        {
            if (!_isInRange)
            {
                _isInRange = true;
                ShowInteractUI(true); // 상호작용 UI 보이기
            }
        }
        else
        {
            if (_isInRange)
            {
                _isInRange = false;
                ShowInteractUI(false); // 상호작용 UI 숨기기
            }
        }
    }

    // 상호작용 UI Fade 처리
    private void ShowInteractUI(bool show)
    {
        if (show)
        {
            foreach (var UI in _InteractUI)
            {
                UI.DOFade(1f, 0.5f);
            }
            foreach (var UI in _InteractUI_TMP)
            {
                UI.DOFade(1f, 0.5f);
            }
        }
        else
        {
            foreach (var UI in _InteractUI)
            {
                UI.DOFade(0f, 0.5f);
            }
            foreach (var UI in _InteractUI_TMP)
            {
                UI.DOFade(0f, 0.5f);
            }
        }
    }

    // E 키 입력 처리
    private void HandleInput()
    {
        if (_isInRange && Input.GetKeyDown(KeyCode.E))
        {
            Pressed(); // 상호작용 메서드 호출
        }
    }

    // 상호작용 메서드
    private void Pressed()
    {
        OnInteracted?.Invoke();
    }

    // 디버깅용: 감지 범위 표시
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, interactionRadius);
    }
}
