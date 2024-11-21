using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : State
{

    
    protected Player _player;
    public void InitializeState(Player player)
    {
        _player = player;
    }


    protected virtual void HandleLeftMousePressed()
    {
        _player.TransitionState(_player.StateCompo.GetState(StateType.Attack));
    }

    protected virtual void HandleTabKey()
    {
        _player.TransitionState(_player.StateCompo.GetState(StateType.Change));
    }

    protected virtual void HandleFKey()
    {
        _player.TransitionState(_player.StateCompo.GetState(StateType.Skill));
    }

    public override void Enter()
    {
        EnterState();
        _player.InputCompo.OnLeftMouse += HandleLeftMousePressed;
        _player.InputCompo.OnMove += HandleMovement;
        _player.InputCompo.OnTabKey += HandleTabKey;
        _player.InputCompo.OnFKey += HandleFKey;
    }
    public override void Exit()
    {
        ExitState();
        _player.InputCompo.OnLeftMouse -= HandleLeftMousePressed;
        _player.InputCompo.OnMove -= HandleMovement;
        _player.InputCompo.OnTabKey -= HandleTabKey;
        _player.InputCompo.OnFKey -= HandleFKey;
    }
}
