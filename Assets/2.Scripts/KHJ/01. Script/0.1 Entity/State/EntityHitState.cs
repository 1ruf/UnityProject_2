using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityHitState : EntityState
{
    protected override void EnterState()
    {
        _entity.RbCompo.velocity = Vector2.zero;
        _entity.AnimCompo.PlayAnimaton(AnimationType.hit);
        _entity.AnimCompo.OnAnimationAction.AddListener(Hit);
        _entity.AnimCompo.OnAnimationEnd.AddListener(TransitionState);
    }


    private void TransitionState()
    {
        _entity.TransitionState(_entity.StateCompo.GetState(StateType.Idle));
    }

    private void Hit()
    {
        print("¸Â¾Ò´Ù");
    }

    protected override void ExitState()
    {
        _entity.AnimCompo.ResetEvent();
    }
}
