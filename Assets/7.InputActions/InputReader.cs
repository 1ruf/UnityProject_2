using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static KeyAction;

[CreateAssetMenu(menuName = "SO/InputReader")]

public class InputReader : ScriptableObject, IPlayerActions
{
    public event Action <Vector2> OnMove;       //�̵� �̺�Ʈ
    public event Action OnLeftMouse;
    public event Action OnTabKey;
    public event Action OnFKey;

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

    public void OnMovement(InputAction.CallbackContext context)
    {
        OnMove?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnAttack(InputAction.CallbackContext context) // ��Ŭ��
    {
        
        if (context.performed)
        {
            OnLeftMouse?.Invoke();
        }
    }

    

    public void OnCharacterSkill(InputAction.CallbackContext context) // F Ű
    {
        if (context.performed)
        {
            OnFKey?.Invoke();
        }
    }

    public void OnChangeSkill(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnTabKey?.Invoke();
        }
    }
}

