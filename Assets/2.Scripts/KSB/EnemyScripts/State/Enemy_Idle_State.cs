using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Idle_State : EnemyState
{
    public Enemy_Idle_State(Enemy enemy, EnemyStateMachine stateMachine, string animBoolHash) : base(enemy, stateMachine, animBoolHash)
    {
    }
}
