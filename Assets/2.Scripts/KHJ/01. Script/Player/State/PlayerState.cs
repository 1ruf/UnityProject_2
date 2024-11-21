using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : State
{
    public override void Enter()
    {
        EnterState();
        if (_npc.InputCompo == null) return;
        _npc.InputCompo.OnLeftMouse += HandleLeftMousePressed;
        _npc.InputCompo.OnMove += HandleMovement;
        _npc.InputCompo.OnTabKey += HandleTabKey;
        _npc.InputCompo.OnFKey += HandleFKey;
    }
    public override void Exit()
    {
        ExitState();

        if (_npc.InputCompo == null) return;
        _npc.InputCompo.OnLeftMouse -= HandleLeftMousePressed;
        _npc.InputCompo.OnMove -= HandleMovement;
        _npc.InputCompo.OnTabKey -= HandleTabKey;
        _npc.InputCompo.OnFKey -= HandleFKey;
    }
}
