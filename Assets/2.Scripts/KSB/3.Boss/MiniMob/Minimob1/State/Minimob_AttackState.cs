using System.Collections;
using UnityEngine;

public class Minimob_AttackState : BossState
{
    bool isAttacking = false;
    public override void StateFixedUpdate()
    {
        base.StateFixedUpdate();
    }

    public override void StateUpdate()
    {

        if (!isAttacking)
            StartCoroutine(AttacPattern());

        if (!_minimob.Detecting.isDetecting)
        {
            _minimob.TransitionState(_minimob.StateCompo.Boss_GetState(Boss_StateType.Idle));
        }

        if (!_minimob.Detecting.startAttack)
        {
            _minimob.TransitionState(_minimob.StateCompo.Boss_GetState(Boss_StateType.Run));
        }

        if (_minimob.health <= 0)
        {
            _minimob.TransitionState(_minimob.StateCompo.Boss_GetState(Boss_StateType.Death));
        }


    }


    IEnumerator AttacPattern()
    {
        isAttacking = true;
        if (_minimob.CanAttack == true)
        {
            _minimob.ChoseRandomAttack();
            yield return new WaitForSeconds(0.7f);
            isAttacking = false;
        }


    }

    protected override void ExitState()
    {
        isAttacking = false ;
    }
}
