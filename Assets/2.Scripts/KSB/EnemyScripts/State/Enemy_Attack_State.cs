using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Attack_State : EnemyState
{
    public Enemy_Attack_State(Enemy enemy, EnemyStateMachine stateMachine, string animBoolHash) : base(enemy, stateMachine, animBoolHash)
    {

    }

}
