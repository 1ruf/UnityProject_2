using UnityEngine;

public class IdleState : PlayerState
{
    
    protected override void EnterState()
    {
        _player.AnimCompo.PlayAnimaton(AnimationType.idle);
        _player.RbCompo.velocity = Vector2.zero;
    }

    public override void StateFixedUpdate()
    {
        if (_player.InputCompo.InputVector.magnitude > 0)
            _player.TransitionState(_player.StateCompo.GetState(StateType.Move));

    }
}
