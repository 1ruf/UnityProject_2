using UnityEngine;

public abstract class State : MonoBehaviour
{
    

    

    protected virtual void HandleMovement(Vector2 vector)
    {
        
    }

    protected virtual void HandleJumpPressed()
    {

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
