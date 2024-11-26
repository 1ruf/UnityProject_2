using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMoveState : EntityState
{

    protected override void EnterState()
    {
        _entity.AnimCompo.PlayAnimaton(AnimationType.run);
    }

    public override void StateFixedUpdate()
    {
        //if (_entity.gameObject.CompareTag("Player")) print("플레이어 무브");
        if (_entity.MoveDire.magnitude <= 0)
            _entity.TransitionState(_entity.StateCompo.GetState(StateType.Idle));
        else
            _entity.RbCompo.velocity = _entity.MoveDire * _entity._speed;

        if (_entity._currentHp < 0)
            _entity.TransitionState(_entity.StateCompo.GetState(StateType.Death));
    }
}
