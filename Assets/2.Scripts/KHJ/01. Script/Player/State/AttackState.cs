using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackState : PlayerState
{


    protected override void EnterState()
    {

        _player.AnimCompo.PlayAnimaton(AnimationType.attack);
        /*_player.AnimCompo.OnAnimationAction += PerfromAttack;
        _player.AnimCompo.OnAnimationEnd += TransitionState;*/
    }

    private void TransitionState()
    {
        _player.TransitionState(_player.StateCompo.GetState(StateType.Idle));
        ExitState();
    }

    private void PerfromAttack()
    {
    }

    protected override void ExitState()
    {
        /*_player.AnimCompo.OnAnimationAction -= PerfromAttack;
        _player.AnimCompo.OnAnimationEnd -= TransitionState;*/
    }

}
