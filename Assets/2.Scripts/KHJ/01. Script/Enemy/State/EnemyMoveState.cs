using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveState : EnemyState
{
    [SerializeField] private float _moveSpeed = 10;

    protected override void EnterState()
    {
        _enemy.AnimCompo.PlayAnimaton(AnimationType.move);
        print("무브 스테이트");

    }

    public override void StateFixedUpdate()
    {
        print(1);
        Vector2 direction = (_enemy.Target.position - _enemy.transform.position).normalized;

        _enemy.RbCompo.velocity = direction * _moveSpeed;

        if (_enemy.CanAttack)
        {
            _enemy.TransitionState(_enemy.StateCompo.GetState(StateType.Attack));
        }

    }
}
