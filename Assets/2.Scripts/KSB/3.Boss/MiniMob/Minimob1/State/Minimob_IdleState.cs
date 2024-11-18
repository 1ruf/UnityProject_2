using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Minimob_IdleState : BossState
{
    protected override void EnterState()
    {
        print("¾Ó");
        _minimob.RbCompo.velocity = Vector3.zero;
        _minimob.AniCompo.Boss_PlayAnimaton(Boss_AnimationType.Idle);
       

    }

    public override void StateFixedUpdate()
    {
      

    }

    public override void StateUpdate()
    {
        if (_minimob.Detecting.isDetecting && !_minimob.Detecting.startAttack)
        {
           _minimob.TransitionState(_minimob.StateCompo.Boss_GetState(Boss_StateType.Run));//follow

        }
        else if (_minimob.Detecting.startAttack)
        {
            _minimob.TransitionState(_minimob.StateCompo.Boss_GetState(Boss_StateType.Attack));
        }

        if (_minimob.Health <= 0)
        {
            _minimob.TransitionState(_minimob.StateCompo.Boss_GetState(Boss_StateType.Death));
        }
    }

    protected override void ExitState()
    {
    
    }

}
