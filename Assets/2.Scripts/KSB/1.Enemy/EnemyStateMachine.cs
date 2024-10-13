using System.Collections.Generic;
public enum EnemyStateEnum
{
    Idle, Move, Attack, Death,Follow
}
public class EnemyStateMachine
{
    public EnemyState currentState;
    public Dictionary<EnemyStateEnum, EnemyState> playerState = new();
    public void Initialize(EnemyStateEnum state)
    {
        currentState = playerState[state];
        currentState.Enter();
    }

    public void AddState(EnemyStateEnum stateEnum, EnemyState state)
    {
        playerState.Add(stateEnum, state);
    }

    public void ChangeState(EnemyStateEnum stateEnum)
    {
        currentState.Exit();
        currentState = playerState[stateEnum];
        currentState.Enter();
    }

}
