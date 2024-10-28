using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState_SB :E_State
{
    protected override void EnterState()
    {
        _agent.AnimationCompo.PlayAnimaiton(AnimationType.die);
    }
}
