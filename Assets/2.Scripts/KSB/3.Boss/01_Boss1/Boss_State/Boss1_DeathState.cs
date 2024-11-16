using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1_DeathState : BossState
{
    protected override void EnterState()
    {
        _boss.AniCompo.Boss_PlayAnimaton(Boss_AnimationType.Death);
    }
}
