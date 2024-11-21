using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateFectory : StateFectory
{


    public override State GetState(StateType stateType)
        => stateType switch
        {
            StateType.Idle => Idle,
            StateType.Move => Move,
            StateType.Attack => Attack,
            StateType.Hit => Hit,
            StateType.Death => Death,
            _ => throw new System.Exception("aa")
        };
}
