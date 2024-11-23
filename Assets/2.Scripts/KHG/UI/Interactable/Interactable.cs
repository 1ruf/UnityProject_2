using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class Interactable : MonoBehaviour
{
    [SerializeField] private float interactionRadius = 3f; // ���� ����
    [SerializeField] private LayerMask interactableLayer; // ��ȣ�ۿ� ������ ���̾� ����
    [SerializeField] private Image[] _InteractUI; // ��ȣ�ۿ� UI
    [SerializeField] private TextMeshProUGUI[] _InteractUI_TMP; // ��ȣ�ۿ� UI
    private Collider[] _overlapResults = new Collider[10]; // OverlapSphere ��� ����
    private bool _isInRange = false; // ��ȣ�ۿ� ���� �� �ִ��� Ȯ��

    public UnityEvent OnInteracted;

    private void Update()
    {
        CheckForInteractable();
        HandleInput();
    }

    // OverlapSphere�� ����� ��ȣ�ۿ� ������ ������Ʈ Ž��
    private void CheckForInteractable()
    {
        Collider2D plr = Physics2D.OverlapCircle(transform.position, interactionRadius,interactableLayer);

        if (plr != null)
        {
            if (!_isInRange)
            {
                _isInRange = true;
                ShowInteractUI(true); // ��ȣ�ۿ� UI ���̱�
            }
        }
        else
        {
            if (_isInRange)
            {
                _isInRange = false;
                ShowInteractUI(false); // ��ȣ�ۿ� UI �����
            }
        }
    }

    // ��ȣ�ۿ� UI Fade ó��
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

    // E Ű �Է� ó��
    private void HandleInput()
    {
        if (_isInRange && Input.GetKeyDown(KeyCode.E))
        {
            Pressed(); // ��ȣ�ۿ� �޼��� ȣ��
        }
    }

    // ��ȣ�ۿ� �޼���
    private void Pressed()
    {
        OnInteracted?.Invoke();
    }

    // ������: ���� ���� ǥ��
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, interactionRadius);
    }
}
