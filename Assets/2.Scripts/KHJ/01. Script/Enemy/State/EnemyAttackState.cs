using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyState
{



    protected override void EnterState()
    {
        print("���ݻ��¿� �Ծ� ����");
        _enemy.RbCompo.velocity = Vector2.zero;
        _enemy.AnimCompo.PlayAnimaton(AnimationType.attack);
        _enemy.AnimCompo.OnAnimationAction += TransitionState;
        _enemy.AnimCompo.OnAnimationEnd += PerfromAttack;
        
    }
    

    private void TransitionState()
    { // ���� ���� ��
        print("���ݳ��̿� �Ծ� ����");
        _enemy.TransitionState(_enemy.StateCompo.GetState(StateType.Idle));
    }

    private void PerfromAttack()
    {
        // ���� ��� ����
    }

}
