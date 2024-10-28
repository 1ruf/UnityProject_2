using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState_SB : E_State
{
    protected override void EnterState()
    {
       _agent.AnimationCompo.PlayAnimaiton(AnimationType.attack);
    }

    public override void StateFixedUpdate()
    {
        base.StateFixedUpdate();
    }

    public override void StateUpdate()
    {
        Flip();
        if(_agent.Hp<=0)
        {
            _agent.TransitionState(_agent.DeathState);
        }
        if(!_agent._sensing.Attack&& !_agent._sensing.Detected)
            _agent.TransitionState(_agent.MoveState);

        if (!_agent._sensing.Attack)
        {
            _agent.TransitionState(_agent.FollowState);

        }

    }

    protected override void Flip()
    {
        base.Flip();
    }
}