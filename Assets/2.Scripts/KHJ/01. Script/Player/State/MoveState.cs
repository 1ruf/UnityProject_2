using UnityEngine;

public class MoveState : PlayerState
{

    protected override void EnterState()
    {
        base._player.AnimCompo.PlayAnimaton(AnimationType.move);
    }


    public override void StateFixedUpdate()
    {
        Move();
        if (_player.InputCompo.InputVector.magnitude <= 0)
        {

            _player.TransitionState(_player.StateCompo.GetState(StateType.Idle));
        }
    }

    private void Move()
    {
        _player.RbCompo.velocity = _player.InputCompo.InputVector;
    }
}
