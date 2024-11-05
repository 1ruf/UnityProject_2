using UnityEngine;

public abstract class State : MonoBehaviour
{
    protected Player _agent;

    

    public void InitializeState(Player player)
    {
        _agent = player;
    }

    protected virtual void HandleMovement(Vector2 vector)
    {
        
    }

    protected virtual void HandleJumpPressed()
    {

    }

    protected virtual void HandleLeftMousePressed()
    {
        _agent.TransitionState(_agent.StateCompo.GetState(StateType.Attack));
    }

    protected virtual void HandleTabKey()
    {
        _agent.TransitionState(_agent.StateCompo.GetState(StateType.Change));
    }

    protected virtual void HandleFKey()
    {
        _agent.TransitionState(_agent.StateCompo.GetState(StateType.Skill));
    }

    public virtual void StateFixedUpdate()
    {

    }

    public virtual void StateUpdate()
    {

    }

    protected virtual void EnterState()
    {

    }

    protected virtual void ExitState()
    {

    }


    public void Enter()
    {
        _agent.InputCompo.OnLeftMouse += HandleLeftMousePressed;
        _agent.InputCompo.OnMove += HandleMovement;
        _agent.InputCompo.OnTabKey += HandleTabKey;
        _agent.InputCompo.OnFKey += HandleFKey;
        EnterState();
    }
    public void Exit()
    {
        _agent.InputCompo.OnLeftMouse -= HandleLeftMousePressed;
        _agent.InputCompo.OnMove -= HandleMovement;
        _agent.InputCompo.OnTabKey -= HandleTabKey;
        _agent.InputCompo.OnFKey -= HandleFKey;
        ExitState();
    }

}
