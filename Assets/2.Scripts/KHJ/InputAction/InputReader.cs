using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static KeyAction;

[CreateAssetMenu(menuName = "SO/InputReader")]

public class InputReader : ScriptableObject, IPlayerActions
{
    public event Action<Vector2> OnMove;       //�̵� �̺�Ʈ
    public event Action OnJumpPressed;         //���� �̺�Ʈ
    public event Action OnLeftMouse;

    public Vector2 InputVector { get; private set; }

    private KeyAction _playerInputAction;

    private void OnEnable()
    {
        if (_playerInputAction == null)
        {
            _playerInputAction = new KeyAction();
            _playerInputAction.Player.SetCallbacks(this);  //�÷��̾� ��ǲ�� �߻��ϸ� �� �ν��Ͻ��� ����
        }
        _playerInputAction.Player.Enable(); //Ȱ��ȭ
    }

    public void OnSpace(InputAction.CallbackContext context)
    {
        if (context.performed)
            OnJumpPressed?.Invoke();
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        
        OnMove?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
            OnLeftMouse?.Invoke();
    }
}

