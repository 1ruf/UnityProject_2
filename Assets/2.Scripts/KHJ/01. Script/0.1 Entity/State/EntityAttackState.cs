using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAttackState : EntityState
{
    protected override void EnterState()
    {
        _entity.RbCompo.velocity = Vector2.zero;
        _entity.AnimCompo.PlayAnimaton(AnimationType.attack);
        _entity.AnimCompo.OnAnimationAction.AddListener(PerfromAttack);
        _entity.AnimCompo.OnAnimationEnd.AddListener(TransitionState);
    }


    private void TransitionState()
    {
        _entity.TransitionState(_entity.StateCompo.GetState(StateType.Idle));
    }

    private void PerfromAttack()
    {
        _entity.AttackPoint.position = (Vector2)_entity.transform.position + _entity.MoveDire * 5;
        BasicAttack.Instance.Attack(_entity.AttackPoint.position, _entity.AttackPoint.lossyScale, 5, _entity.EnemyContol.enabled ? "Player" : "Enemy");
    }

    


    protected override void ExitState()
    {
        _entity.AnimCompo.ResetEvent();
    }
}
