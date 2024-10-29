using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StateFectory : MonoBehaviour
{

    [SerializeField] private State Idle, Move, Attack, Change, Skill;


    public State GetState(StateType stateType)
        => stateType switch
        {
            StateType.Idle => Idle,
            StateType.Move => Move,
            StateType.Attack => Attack,
            StateType.Change => Change,
            StateType.Skill => Skill,
            _ => throw new System.Exception("hay what the fuck")
        };

    public void InitializeState(Player agent)
    {
        State[] states = GetComponents<State>();
        foreach (State state in states)
            state.InitializeState(agent);
    }
}



public enum StateType
{
    Idle,
    Move,
    Attack,
    Change,
    Skill
}