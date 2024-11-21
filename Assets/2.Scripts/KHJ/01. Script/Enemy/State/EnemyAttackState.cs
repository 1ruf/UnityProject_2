using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyState
{



    protected override void EnterState()
    {
        print("공격상태요 님아 제발");
        _enemy.RbCompo.velocity = Vector2.zero;
        _enemy.AnimCompo.PlayAnimaton(AnimationType.attack);
        _enemy.AnimCompo.OnAnimationAction += TransitionState;
        _enemy.AnimCompo.OnAnimationEnd += PerfromAttack;
        
    }
    

    private void TransitionState()
    { // 공격 상태 끝
        print("공격끝이요 님아 제발");
        _enemy.TransitionState(_enemy.StateCompo.GetState(StateType.Idle));
    }

    private void PerfromAttack()
    {
        // 공격 기능 실행
    }

}
