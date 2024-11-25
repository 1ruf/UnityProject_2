using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityState : MonoBehaviour
{
    protected Entity _entity;
    public void InitializeState(Entity entity)
    {
        _entity = entity;
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
        EnterState();
    }
    public void Exit()
    {
        ExitState();
    }
}
