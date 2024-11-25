using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static KeyAction;

[CreateAssetMenu(menuName = "SO/InputReader")]

public class InputReader : ScriptableObject, IPlayerActions
{
    public event Action <Vector2> OnMove;       //이동 이벤트
    public event Action OnLeftMouse;
    public event Action OnTabKey;
    public event Action OnFKey;

    private KeyAction _playerInputAction;

    private void OnEnable()
    {
        if (_playerInputAction == null)
        {
            _playerInputAction = new KeyAction();
            _playerInputAction.Player.SetCallbacks(this);  //플레이어 인풋이 발생하면 이 인스턴스를 연결
        }
        _playerInputAction.Player.Enable(); //활성화
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        OnMove?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnAttack(InputAction.CallbackContext context) // 좌클릭
    {
        
        if (context.performed)
        {
            OnLeftMouse?.Invoke();
        }
    }

    

    public void OnCharacterSkill(InputAction.CallbackContext context) // F 키
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

