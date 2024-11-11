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
     
        if (_sensing.Detected)
        {
            _agent.TransitionState(_agent.GetState<FollowState_SB>());
        }
        else if (_agent.transform.position != _agent.point)
        {
            Debug.Log("toMove");
            _agent.TransitionState(_agent.GetState<MoveState_SB>());
        }
    
       
      
       

      
    }

    public override void StateFixedUpdate()
    {
        base.StateFixedUpdate();
        
    }
}
