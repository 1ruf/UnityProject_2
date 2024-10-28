using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{

    [SerializeField] private MovementData _movementData;
    protected override void EnterState()
    {
        _agent.AnimCompo.PlayAnimaton(AnimatonType.walk);
    }

    protected override void HandleMovement(Vector2 vector)
    {
        _movementData.moveDir = vector;
        
    }

    public override void StateFixedUpdate()
    {
        Move();
        if (_movementData.moveDir.magnitude <= 0)
        {
            _agent.TransitionState(_agent.StateCompo.GetState(StateType.Idle));
        }
    }

    private void Move()
    {
        _agent.RbCompo.velocity = _movementData.moveDir;
    }
}
