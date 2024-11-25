using System;
using UnityEngine;


public class StateFectory : MonoBehaviour
{

    [SerializeField] protected EntityState Idle, Move, Attack, Death, Hit;

    public EntityState GetState(StateType stateType)
        => stateType switch
        {
            StateType.Idle => Idle,
            StateType.Move => Move,
            StateType.Attack => Attack,
            StateType.Hit => Hit,
            StateType.Death => Death,
            _ => throw new System.Exception("aa")
        };

    public void InitializeState(Entity entity)
    {
        EntityState[] states = GetComponents<EntityState>();
        foreach (EntityState state in states)
            state.InitializeState(entity);
    }

    public bool StateCheck(EntityState state)
    {
        if (state == Idle || state == Move)
        {
            return true;
        }
        print("helo");
        return false;
        
    }
}



public enum StateType
{
    Idle,
    Move,
    Attack,
    Hit,
    Death,
}