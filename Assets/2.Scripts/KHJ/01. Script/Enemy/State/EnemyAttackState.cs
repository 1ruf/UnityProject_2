using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyState
{



    protected override void EnterState()
    {
        print("����");

        _enemy.RbCompo.velocity = Vector2.zero;
        _enemy.AnimCompo.PlayAnimaton(AnimationType.attack);
        _enemy.AnimCompo.OnAnimationAction.AddListener(PerfromAttack);
        _enemy.AnimCompo.OnAnimationEnd.AddListener(TransitionState);
    }


    private void TransitionState()
    { 
        print("���� ��");
        _enemy.TransitionState(_enemy.StateCompo.GetState(StateType.Idle));
    }

    private void PerfromAttack()
    {
    }

    protected override void ExitState()
    {
        _enemy.AnimCompo.ResetEvent();
    }
}
