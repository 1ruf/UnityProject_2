using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveState : EnemyState
{
    [SerializeField] private float _moveSpeed = 4;

    protected override void EnterState()
    {
        _enemy.AnimCompo.PlayAnimaton(AnimationType.move);
        print("¹«ºê");

    }

    public override void StateFixedUpdate()
    {
        if (_enemy.Target == null)
        {
            _enemy.TransitionState(_enemy.StateCompo.GetState(StateType.Idle));
            return;
        }
        Vector2 direction = (_enemy.Target.position - _enemy.transform.position).normalized;

        _enemy.RbCompo.velocity = direction * _moveSpeed;

        if (_enemy.CanAttack)
        {
            _enemy.TransitionState(_enemy.StateCompo.GetState(StateType.Attack));
        }

    }
}
