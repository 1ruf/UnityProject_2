using System.Collections;
using UnityEngine;

public class Minimob_AttackState : BossState
{
   
    public override void StateFixedUpdate()
    {

        StartCoroutine(AttacPattern());
        base.StateFixedUpdate();
    }

    public override void StateUpdate()
    {

        if (!_minimob.Detecting.isDetecting)
        {
            _minimob.TransitionState(_minimob.StateCompo.Boss_GetState(Boss_StateType.Idle));
        }

        if (!_minimob.Detecting.startAttack)
        {
            _minimob.TransitionState(_minimob.StateCompo.Boss_GetState(Boss_StateType.Run));
        }

        if (_minimob.Health <= 0)
        {
            _minimob.TransitionState(_minimob.StateCompo.Boss_GetState(Boss_StateType.Death));
        }


    }


    IEnumerator AttacPattern()
    {
     
        if (_minimob.CanAttack == true)
        {
            _minimob.ChoseRandomAttack();
            yield return new WaitForSeconds(0.7f);
        }


    }

}
