using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimob_RunState : BossState
{
    protected override void EnterState()
    {
        _minimob.AniCompo.Boss_PlayAnimaton(Boss_AnimationType.Run);
    }

    public override void StateFixedUpdate()
    {
        base.StateFixedUpdate();
    }

    public override void StateUpdate()
    {
        Follow();
        if (_minimob.Detecting.startAttack)
        {
            _minimob.TransitionState(_minimob.StateCompo.Boss_GetState(Boss_StateType.Attack));
        }
        if (_minimob.health <= 0)
        {
            _minimob.TransitionState(_minimob.StateCompo.Boss_GetState(Boss_StateType.Death));
        }
        if (!_minimob.Detecting.isDetecting)
        {
            _minimob.TransitionState(_minimob.StateCompo.Boss_GetState(Boss_StateType.Idle));
        }
    }

    private void Follow()
    {
        GameObject target = _minimob.Detecting.target;
        if (target != null)
        {
            Vector2 targetPosition = target.transform.position;
            Vector2 direction = (targetPosition - _minimob.RbCompo.position).normalized;

            _minimob.RbCompo.velocity = (direction * 3); // 수정할겨
        }
    }

    protected override void ExitState()
    {
        _minimob.RbCompo.velocity = Vector3.zero;
    }
}
