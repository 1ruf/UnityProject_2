using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAttackState : EntityState
{
    private Vector2 _attackPointMoveDire;
    protected override void EnterState()
    {
        _attackPointMoveDire = new Vector2(_entity.AnimCompo.Animator.GetFloat("MoveX"), _entity.AnimCompo.Animator.GetFloat("MoveY"));
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
        _entity.AttackPoint.position = (Vector2)_entity.transform.position + _attackPointMoveDire;
        BasicAttack.Instance.Attack(_entity.AttackPoint.position, _entity.AttackPoint.lossyScale, 5, _entity.EnemyContol.enabled ? "Player" : "Enemy");
    }

    


    protected override void ExitState()
    {
        _entity.AnimCompo.ResetEvent();
    }
}
