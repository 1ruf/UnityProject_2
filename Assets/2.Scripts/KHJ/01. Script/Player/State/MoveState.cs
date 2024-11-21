using UnityEngine;

public class MoveState : State
{

    protected override void EnterState()
    {
        _npc.AnimCompo.PlayAnimaton(AnimationType.move);
    }

    

    public override void StateFixedUpdate()
    {
        Move();
        if (_npc.InputCompo.InputVector.magnitude <= 0)
        {

            _npc.TransitionState(_npc.StateCompo.GetState(StateType.Idle));
        }
    }

    private void Move()
    {
        _npc.RbCompo.velocity = _npc.InputCompo.InputVector;
    }
}
