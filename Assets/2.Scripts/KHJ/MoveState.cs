using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{

    [SerializeField] private MovementData _movementData;
    protected override void EnterState()
    {
        Debug.Log("축하합니다 당신은 Movement 상태에 돌입 하였습니다!");
    }

    protected override void HandleMovement(Vector2 vector)
    {
        _movementData.moveDir = vector;

    }

    public override void StateFixedUpdate()
    {
        Move();
        if (_movementData.moveDir.magnitude == 0)
        {
            _agent.TransitionState(_agent.StateCompo.GetState(StateType.Idle));
        }
    }

    private void Move()
    {
        _agent.RbCompo.velocity = _movementData.moveDir;
    }
}
