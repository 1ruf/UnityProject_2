using UnityEngine;

public abstract class State : MonoBehaviour
{
    protected Npc _npc;

    

    public void InitializeState(Npc npc)
    {
        _npc = npc;
    }

    protected virtual void HandleMovement(Vector2 vector)
    {
        
    }

    protected virtual void HandleJumpPressed()
    {

    }

    protected virtual void HandleLeftMousePressed()
    {
        _npc.TransitionState(_npc.StateCompo.GetState(StateType.Attack));
    }

    protected virtual void HandleTabKey()
    {
        _npc.TransitionState(_npc.StateCompo.GetState(StateType.Change));
    }

    protected virtual void HandleFKey()
    {
        _npc.TransitionState(_npc.StateCompo.GetState(StateType.Skill));
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
        _npc.InputCompo.OnLeftMouse += HandleLeftMousePressed;
        _npc.InputCompo.OnMove += HandleMovement;
        _npc.InputCompo.OnTabKey += HandleTabKey;
        _npc.InputCompo.OnFKey += HandleFKey;
        EnterState();
    }
    public void Exit()
    {
        _npc.InputCompo.OnLeftMouse -= HandleLeftMousePressed;
        _npc.InputCompo.OnMove -= HandleMovement;
        _npc.InputCompo.OnTabKey -= HandleTabKey;
        _npc.InputCompo.OnFKey -= HandleFKey;
        ExitState();
    }

}
