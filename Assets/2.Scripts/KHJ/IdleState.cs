using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{

    protected override void ExitState()
    {
        //_agent.AnimCompo.PlayAnimaiton(AnimationType.idle);
        _agent.RbCompo.velocity = Vector2.zero;
    }

    protected override void HandleMovement(Vector2 vector)
    {
        Debug.Log(vector);
        if (vector.magnitude > 0)
        {
            _agent.TransitionState(_agent.StateCompo.GetState(StateType.Move));
        }
    }
}
