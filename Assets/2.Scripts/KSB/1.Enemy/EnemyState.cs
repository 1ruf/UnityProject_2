using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EnemyStateMachine;

public class EnemyState 
{
    public int AnimBoolHash;
    public Enemy Enemy;

    public EnemyStateMachine StateMachine;
    public bool IsTriggerCalled;
    Animator animator;

    public virtual void Update()
    {

    }

    public EnemyState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolHash)
    {
        Enemy = enemy;
        StateMachine = stateMachine;
        AnimBoolHash = Animator.StringToHash(animBoolHash);

        animator = Enemy.animator;
    }


    public virtual void Enter()
    {
       // animator.SetBool(AnimBoolHash, true);
        IsTriggerCalled = false;
    }

    public virtual void Exit()
    {
      // animator.SetBool(AnimBoolHash, false);

    }

    public void TriggerCalled()
    {
        IsTriggerCalled = true;
    }
}
