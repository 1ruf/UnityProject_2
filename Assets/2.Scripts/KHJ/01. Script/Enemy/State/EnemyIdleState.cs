using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyState
{
    protected override void EnterState()
    {
        _enemy.RbCompo.velocity = Vector2.zero;
        _enemy.AnimCompo.PlayAnimaton(AnimationType.idle);
        print("ถ๓ภฬต้");
    }

    public override void StateFixedUpdate()
    {
        if (_enemy.Target)
        {
            _enemy.TransitionState(_enemy.StateCompo.GetState(StateType.Move));
        }
    }
}
