using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public abstract class State : MonoBehaviour
{
    protected Player _agent;

    

    public void InitializeState(Player player)
    {
        _agent = player;
    }

    protected virtual void HandleMovement(Vector2 vector)
    {
        
    }

    protected virtual void HandleJumpPressed()
    {

    }

    protected virtual void HandleLeftMousePressed()
    {
        _agent.TransitionState(_agent.StateCompo.GetState(StateType.Attack));
    }


    public virtual void StateFixedUpdate()
    {

    }

    public virtual void StateUpdate()
    {

    }

    protected virtual void EnterState()
    {

    }

    protected virtual void ExitState()
    {

    }


    public void Enter()
    {
        _agent.InputCompo.OnLeftMouse += HandleLeftMousePressed;
        _agent.InputCompo.OnMove += HandleMovement;
        EnterState();
    }
    public void Exit()
    {
        _agent.InputCompo.OnLeftMouse -= HandleLeftMousePressed;
        _agent.InputCompo.OnMove -= HandleMovement;
        ExitState();
    }

}
