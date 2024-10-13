using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Follow_State : EnemyState
{
    public Enemy_Follow_State(Enemy enemy, EnemyStateMachine stateMachine, string animBoolHash) : base(enemy, stateMachine, animBoolHash)
    {
    }

}
