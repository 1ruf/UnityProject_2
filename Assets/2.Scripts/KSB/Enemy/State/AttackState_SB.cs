using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState_SB : E_State
{
    protected override void EnterState()
    {
       _agent.AnimationCompo.PlayAnimaiton(AnimationType.attack);
    }

    public override void StateFixedUpdate()
    {
        base.StateFixedUpdate();
    }

    public override void StateUpdate()
    {
        Flip();
    }

    protected override void Flip()
    {
        base.Flip();
    }
}