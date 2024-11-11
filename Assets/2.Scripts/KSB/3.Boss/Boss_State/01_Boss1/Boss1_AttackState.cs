using System.Collections;
using UnityEngine;

public class Boss1_AttackState : E_State
{
    public delegate void AttackAction();
    public AttackAction OnAttack1;
    public AttackAction OnAttack2;
    public AttackAction OnAttack3;
    //private 
   
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
        if(!isAttacking)
        StartCoroutine(AttacPattern());
    }

    IEnumerator AttacPattern()
    {
        isAttacking = true;
        _boss.ChoseRandomAttack();
        yield return new WaitForSeconds(_boss.GetDelay());
        isAttacking = false;

    }

   

}
