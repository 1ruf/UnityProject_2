using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyState
{
    protected override void EnterState()
    {
        print("ถ๓ภฬต้");

        _enemy.RbCompo.velocity = Vector2.zero;
        _enemy.AnimCompo.PlayAnimaton(AnimationType.idle);
    }

    public override void StateFixedUpdate()
    {
        
        if (_enemy.Target && _enemy.CanAttack)
        {
            _enemy.TransitionState(_enemy.StateCompo.GetState(StateType.Move));
        }
        else if (_enemy.Target)
        {
            _enemy.TransitionState(_enemy.StateCompo.GetState(StateType.Move));
        }
    }
}
