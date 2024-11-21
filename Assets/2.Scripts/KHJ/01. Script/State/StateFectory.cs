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
            _ => throw new System.Exception("aa")
        };

    public void InitializeState(Npc npc)
    {
        State[] states = GetComponents<State>();
        foreach (State state in states)
            state.InitializeState(npc);
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