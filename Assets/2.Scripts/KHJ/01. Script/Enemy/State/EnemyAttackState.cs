using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : State
{


    protected override void EnterState()
    {
        print("에너미 어택 스테이트");
        _npc.AnimCompo.PlayAnimaton(AnimationType.attack);
        _npc.AnimCompo.OnAnimationAction.AddListener(PerfromAttack);
        _npc.AnimCompo.OnAnimationEnd.AddListener(TransitionState);
    }
    

    private void TransitionState()
    { // 공격 상태 끝
        _npc.TransitionState(_npc.StateCompo.GetState(StateType.Idle));
    }

    private void PerfromAttack()
    {
        // 공격 기능 실행
    }

}
