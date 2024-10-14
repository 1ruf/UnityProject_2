using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Death_State : EnemyState
{
    public Enemy_Death_State(Enemy enemy, EnemyStateMachine stateMachine, string animBoolHash) : base(enemy, stateMachine, animBoolHash)
    {
    }
}
