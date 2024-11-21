using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : State
{


    protected override void EnterState()
    {
        print("���ʹ� ���� ������Ʈ");
        _npc.AnimCompo.PlayAnimaton(AnimationType.attack);
        _npc.AnimCompo.OnAnimationAction.AddListener(PerfromAttack);
        _npc.AnimCompo.OnAnimationEnd.AddListener(TransitionState);
    }
    

    private void TransitionState()
    { // ���� ���� ��
        _npc.TransitionState(_npc.StateCompo.GetState(StateType.Idle));
    }

    private void PerfromAttack()
    {
        // ���� ��� ����
    }

}
