using UnityEngine;


public class StateFectory : MonoBehaviour
{

    [SerializeField] protected State Idle, Move, Attack, Death, Hit;



    public virtual State GetState(StateType stateType)
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



public enum StateType
{
    Idle,
    Move,
    Attack,
    Change,
    Skill,
    Hit,
    Death,
}