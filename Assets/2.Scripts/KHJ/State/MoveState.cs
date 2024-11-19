using UnityEngine;

public class MoveState : State
{

    protected override void EnterState()
    {
        print("¹«ºê");

        _agent.AnimCompo.PlayAnimaton(AnimatonType.walk);
    }

    

    public override void StateFixedUpdate()
    {
        Move();
        if (_agent.InputCompo.InputVector.magnitude <= 0)
        {

            _agent.TransitionState(_agent.StateCompo.GetState(StateType.Idle));
        }
    }

    private void Move()
    {
        _agent.RbCompo.velocity = _agent.InputCompo.InputVector;
    }
}
