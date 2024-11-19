using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackState : State
{
    protected override void EnterState()
    {
        _agent.AnimCompo.PlayAnimaton(AnimatonType.attack);
        _agent.AnimCompo.OnAnimationAction.AddListener(PerfromAttack);
        TransitionState();
    }

    private void TransitionState()
    {
        _agent.TransitionState(_agent.StateCompo.GetState(StateType.Idle));
    }

    private void PerfromAttack()
    {

    }

    protected override void ExitState()
    {
        _agent.AnimCompo.ResetEvent();
    }

}
