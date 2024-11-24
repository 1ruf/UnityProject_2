using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityIdleState : EntityState
{

    protected override void EnterState()
    {
        _entity.RbCompo.velocity = Vector2.zero;
        _entity.AnimCompo.PlayAnimaton(AnimationType.idle);
    }

    public override void StateFixedUpdate()
    {
        if (_entity.MoveDire.magnitude > 0)
        {
            _entity.TransitionState(_entity.StateCompo.GetState(StateType.Move));
        }
    }
}