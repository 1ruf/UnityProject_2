using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveState : State
{
    protected override void EnterState()
    {
        _npc.AnimCompo.PlayAnimaton(AnimationType.move);
        print("무브 스테이트");

    }

    public override void StateFixedUpdate()
    {

    }
}
