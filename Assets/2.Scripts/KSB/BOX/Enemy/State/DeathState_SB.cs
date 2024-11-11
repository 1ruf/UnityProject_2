using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState_SB :E_State
{
    protected override void EnterState()
    {
        print("qw");
        _agent.AnimationCompo.PlayAnimaiton(AnimationType.die);


    }
    public override void StateFixedUpdate()
    {
        base.StateFixedUpdate();
    }

    public override void StateUpdate()
    {
        base.StateUpdate();
    }


}
