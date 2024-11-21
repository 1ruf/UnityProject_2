using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackState : State
{
    protected override void EnterState()
    {
        _npc.AnimCompo.PlayAnimaton(AnimationType.attack);
        _npc.AnimCompo.OnAnimationAction.AddListener(PerfromAttack);
        TransitionState();
    }

    private void TransitionState()
    {
        _npc.TransitionState(_npc.StateCompo.GetState(StateType.Idle));
    }

    private void PerfromAttack()
    {

    }

    protected override void ExitState()
    {
        _npc.AnimCompo.ResetEvent();
    }

}
