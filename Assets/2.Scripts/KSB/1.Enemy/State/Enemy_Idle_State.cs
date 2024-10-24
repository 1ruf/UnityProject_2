using System.Collections;
using UnityEngine;

public class Enemy_Idle_State : EnemyState
{




    public Enemy_Idle_State(Enemy enemy, EnemyStateMachine stateMachine, string animBoolHash) : base(enemy, stateMachine, animBoolHash)
    {

    }

    bool isSurveilling = false; // ���ð� ���� ������ Ȯ���ϴ� ����

    public override void Enter()
    {


    }
    public IEnumerator Surveillance()
    {

        isSurveilling = true;

        for (int i = 1; i < Enemy.Instance.pointer.points.Length; i++)
        {
            if (Enemy.transform.position != Enemy.Instance.pointer.points[i])
            {
                Enemy.transform.position = Vector2.MoveTowards(Enemy.transform.position, Enemy.Instance.pointer.points[i], 1);
            }
            yield return null;
        }

        yield return new WaitForSeconds(1f);
        isSurveilling = false;
    }
    public override void Exit()
    {

    }


}