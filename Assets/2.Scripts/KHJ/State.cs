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
        print(_agent);
       // _agent.InputCompo.OnMove += HandleMovement;
    }
    public void Exit()
    {

    }

}
