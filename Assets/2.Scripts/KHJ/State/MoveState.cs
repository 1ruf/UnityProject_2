using UnityEngine;

public class MoveState : State
{

    [SerializeField] private MovementData _movementData;
    protected override void EnterState()
    {
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
