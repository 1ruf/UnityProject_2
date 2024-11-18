using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Boss1_AttackState : BossState
{
    public delegate void AttackAction();

    protected override void EnterState()
    {
        StartCoroutine(AttacPattern());
    }

    public override void StateFixedUpdate()
    {
        base.StateFixedUpdate();
    }

    public override void StateUpdate()
    {

         
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

            if (_boss.Health <= 0)
            {
                _boss.TransitionState(_boss.StateCompo.Boss_GetState(Boss_StateType.Death));
            }
        }

    }

    IEnumerator AttacPattern()
    {
        if (_boss.CanAttack == true)
        {
            _boss.ChoseRandomAttack();
            yield return new WaitForSeconds(0.5f);
        }
     

    }
}