using UnityEngine;

public abstract class State : MonoBehaviour
{
    protected virtual Npc _npc { get; set; }

    

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


    public virtual void Enter()
    {
        EnterState();
    }
    public virtual void Exit()
    {
        ExitState();
    }

}
