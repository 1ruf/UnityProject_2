using UnityEngine;

public class IdleState : State
{

    protected override void EnterState()
    {
        _agent.AnimCompo.PlayAnimaton(AnimatonType.idle);
        _agent.RbCompo.velocity = Vector2.zero;
    }

    protected override void HandleMovement(Vector2 vector)
    {
        if (vector.magnitude > 0)
        {
            _agent.TransitionState(_agent.StateCompo.GetState(StateType.Move));
        }
    }
}
