using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1_HitState : BossState
{
    protected override void EnterState()
    {
        _boss.AniCompo.Boss_PlayAnimaton(Boss_AnimationType.Hit);
        StartCoroutine(Timer());

    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(0.5f);
        _boss.TransitionState(_boss.lastState);
    }
   
}
