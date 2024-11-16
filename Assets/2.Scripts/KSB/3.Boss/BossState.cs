using UnityEngine;
using static Boss1_AttackState;

public class BossState : MonoBehaviour
{
    protected Boss _boss;

    public AttackAction OnAttack1;
    public AttackAction OnAttack2;
    public AttackAction OnAttack3;
    public AttackAction OnAttack4;

   

    public void InitializeState(Boss boss)
    {
        _boss = boss;
    }

    public void Enter()
    {
        EnterState();
    }

    protected virtual void EnterState() { }

    public virtual void StateUpdate() { }

    public virtual void StateFixedUpdate() { }

    public void Exit()
    {
        ExitState();
    }

    protected virtual void ExitState() { }
}

