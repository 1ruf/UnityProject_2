using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Boss1_AttackState : BossState
{
    public delegate void AttackAction();
    bool isAttacking = false;


    protected override void EnterState()
    {
        base.EnterState();


    }

    public override void StateFixedUpdate()
    {
        base.StateFixedUpdate();
    }

    public override void StateUpdate()
    {
        if (!isAttacking)
            StartCoroutine(AttacPattern());
        if (_boss.CanAttack)
        {
            if (!_boss.Detecting.isDetecting)
            {
                _boss.TransitionState(_boss.StateCompo.Boss_GetState(Boss_StateType.Move));
            }

            if (!_boss.Detecting.startAttack)
            {
                _boss.TransitionState(_boss.StateCompo.Boss_GetState(Boss_StateType.Run));
            }

            if (_boss.health <= 0)
            {
                _boss.TransitionState(_boss.StateCompo.Boss_GetState(Boss_StateType.Death));
            }
        }
     
    }

    IEnumerator AttacPattern()
    {
        isAttacking = true;
        if (_boss.CanAttack == true)
        {
            _boss.ChoseRandomAttack();
            yield return new WaitForSeconds(0.5f);
            isAttacking = false;
        }
     

    }

    protected override void ExitState()
    {
        isAttacking = false;
    }


}