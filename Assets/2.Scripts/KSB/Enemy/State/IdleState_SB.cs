using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState_SB : E_State
{
  
    protected override void EnterState()
    {
        _agent.AnimationCompo.PlayAnimaiton(AnimationType.idle);
     
    }

    protected override void ExitState()
    {
        base.ExitState();
    }

    public override void StateUpdate()
    {
        if (_agent.transform.position != _agent.point)
        {
            Debug.Log("toMove");
            _agent.shouldMove = true;
          // _agent.TransitionState(_agent._enemySO.MoveState);
        }
       

      
    }

    public override void StateFixedUpdate()
    {
        base.StateFixedUpdate();
        
    }
}
