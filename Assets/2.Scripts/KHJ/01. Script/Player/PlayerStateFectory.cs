using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateFectory : StateFectory
{
    [SerializeField] private State Change, Skill;


    public override State GetState(StateType stateType)
        => stateType switch
        {
            StateType.Idle => Idle,
            StateType.Move => Move,
            StateType.Attack => Attack,
            StateType.Hit => Hit,
            StateType.Death => Death,
            StateType.Change => Change,
            StateType.Skill => Skill,
            _ => throw new System.Exception("aa")
        };
}
