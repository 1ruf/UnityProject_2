using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyState
{
    protected override void EnterState()
    {
        _npc.AnimCompo.PlayAnimaton(AnimationType.idle);
        
    }

    public override void StateFixedUpdate()
    {
        /*if (_npc)
        {
            _npc.TransitionState(_npc.StateCompo.GetState(StateType.Attack));
        }*/
    }
}
