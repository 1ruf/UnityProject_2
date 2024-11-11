using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class E_State : MonoBehaviour
{
    protected KSB_Enemy _agent;
    protected Boss _boss;
    protected Sensing _sensing;

    public void InitializeState(KSB_Enemy agent)
    {
        _agent = agent;
    }

    public void Enter()
    {
        _sensing = _agent.sensing;  
        EnterState(); 
       
    }

    protected virtual void EnterState()
    {
        
    }

    protected virtual void HandleJumpPressed()
    {
    }

    protected virtual void HandleJumpReleased()
    {
    }

    protected virtual void HandleMovement(Vector2 vector)
    {
    }

    public virtual void StateUpdate()
    {
        //상태가 변화하나 기다리고 있음
        //예를들어 idle 상태일 때는 input이 들어오길 기다림
    }

    public virtual void StateFixedUpdate()
    {
        //상태가 변화하나 기다리고 있음
        //예를들어 idle 상태일 때는 input이 들어오길 기다림
    }

    public void Exit()
    {

        ExitState();
    }

    protected virtual void ExitState()
    {
    }

   
}
