using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{

    protected override void EnterState()
    {
        _agent.AnimCompo.PlayAnimaton(AnimatonType.idle);
        _agent.RbCompo.velocity = Vector2.zero;
        print("라이들 상태");
    }

    protected override void HandleMovement(Vector2 vector)
    {
        if (vector.magnitude > 0)
        {
            Debug.Log("조건 충족 무브로 가세요");
            _agent.TransitionState(_agent.StateCompo.GetState(StateType.Move));
        }
    }
}
