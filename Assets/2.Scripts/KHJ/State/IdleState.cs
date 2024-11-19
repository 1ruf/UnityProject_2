using UnityEngine;

public class IdleState : State
{

    protected override void EnterState()
    {
        print("¶óÀÌµé");
        _agent.AnimCompo.PlayAnimaton(AnimatonType.idle);
        _agent.RbCompo.velocity = Vector2.zero;
    }

    public override void StateFixedUpdate()
    {
        print(_agent.InputCompo.InputVector.magnitude);
        if (_agent.InputCompo.InputVector.magnitude > 0)
            _agent.TransitionState(_agent.StateCompo.GetState(StateType.Move));

    }
}
