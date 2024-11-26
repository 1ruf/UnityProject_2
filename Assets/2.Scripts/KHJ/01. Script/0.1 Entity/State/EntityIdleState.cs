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
        //if (_entity.gameObject.CompareTag("Player")) print("플레이어 라이들");
        if (_entity.MoveDire.magnitude > 0)
        {
            _entity.TransitionState(_entity.StateCompo.GetState(StateType.Move));
        }
        if (_entity._currentHp < 0)
            _entity.TransitionState(_entity.StateCompo.GetState(StateType.Death));
    }
}
