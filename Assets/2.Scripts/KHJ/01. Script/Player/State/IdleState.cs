using UnityEngine;

public class IdleState : State
{

    protected override void EnterState()
    {
        _npc.AnimCompo.PlayAnimaton(AnimationType.idle);
        _npc.RbCompo.velocity = Vector2.zero;
    }

    public override void StateFixedUpdate()
    {
        if (_npc.InputCompo.InputVector.magnitude > 0)
            _npc.TransitionState(_npc.StateCompo.GetState(StateType.Move));

    }
}
