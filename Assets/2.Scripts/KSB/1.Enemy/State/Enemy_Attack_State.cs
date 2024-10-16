using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Attack_State : EnemyState
{
    private bool On = false;
    public override void Enter()
    {
        Debug.Log("follow_End");
        Enemy._attack = true;
    }
    public Enemy_Attack_State(Enemy enemy, EnemyStateMachine stateMachine, string animBoolHash) : base(enemy, stateMachine, animBoolHash)
    {

    }
    public override void Update()
    {
        if(!On)
        {
            //StartCoroutine(Attack());
        }
       
    }
    public override void Exit()
    {
        Enemy._attack = false;
    }

    IEnumerator Attack()
    {
        On = true;
        Enemy.Target.HP -= Enemy._damage;
        yield return new WaitForSeconds(Enemy._attack_Speed);
        On = false;
    }
}
