using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSstate_SB : E_State
{
    protected override void EnterState()
    {

        _agent.AnimationCompo.PlayAnimaiton(AnimationType.hit);
        _agent.RbCompo.AddForce(Vector2.right, ForceMode2D.Impulse);
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
