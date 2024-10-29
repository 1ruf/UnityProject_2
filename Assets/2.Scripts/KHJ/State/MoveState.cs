using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{

    [SerializeField] private MovementData _movementData;
    protected override void EnterState()
    {
        print("무브 상태");
        _agent.AnimCompo.PlayAnimaton(AnimatonType.walk);
    }

    

    public override void StateFixedUpdate()
    {
        Move();
        if (_agent.InputCompo.InputVector.magnitude <= 0)
        {
            Debug.Log("조건 충족 라이들로 가세요");

            _agent.TransitionState(_agent.StateCompo.GetState(StateType.Idle));
        }
    }

    private void Move()
    {
        _agent.RbCompo.velocity = _agent.InputCompo.InputVector;
    }
}
