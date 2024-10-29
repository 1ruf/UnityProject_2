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
    public event System.Action OnJumpPressed;         //���� �̺�Ʈ
    public event System.Action OnLeftMouse;
    public event System.Action OnTabKey;
    public event System.Action OnFKey;
    public Vector2 MousePos { get; private set; } 
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
        {
            MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            OnLeftMouse?.Invoke();
        }
    }

    public void OnChangeSkill(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            OnTabKey?.Invoke();
        }
    }

    public void OnCharacterSkill(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnFKey?.Invoke();
        }
    }
}

