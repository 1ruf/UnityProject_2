using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimob_HitState : BossState
{
    protected override void EnterState()
    {
      _minimob.AniCompo.Boss_PlayAnimaton(Boss_AnimationType.Hit);
        StartCoroutine(Hit());
       
    }

    public override void StateFixedUpdate()
    {
        base.StateFixedUpdate();
    }

    public override void StateUpdate()
    {
        base.StateUpdate();
    }
    IEnumerator Hit()
    {
        yield return new WaitForSeconds(0.5f);
        _minimob.TransitionState(_minimob.lastState);
    }
}
