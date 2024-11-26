using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMoveState : EntityState
{
    [SerializeField] private float _moveSpeed = 8;

    protected override void EnterState()
    {
        _entity.AnimCompo.PlayAnimaton(AnimationType.run);
    }

    public override void StateFixedUpdate()
    {
        if (_entity.MoveDire.magnitude <= 0)
            _entity.TransitionState(_entity.StateCompo.GetState(StateType.Idle));
        else
            _entity.RbCompo.velocity = _entity.MoveDire * _moveSpeed;

        if (_entity._currentHp < 0)
            _entity.TransitionState(_entity.StateCompo.GetState(StateType.Death));
    }
}
