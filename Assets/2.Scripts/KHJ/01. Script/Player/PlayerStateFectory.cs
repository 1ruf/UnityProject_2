using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateFectory : StateFectory
{
    [SerializeField] private State Change, Skill;
    [SerializeField] Player _player;

    private void Start()
    {
        InitializeState(_player);
    }


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

    public void InitializeState(Player player)
    {
        State[] states = GetComponents<PlayerState>();
        foreach (PlayerState state in states)
            state.InitializeState(player);
    }
}
