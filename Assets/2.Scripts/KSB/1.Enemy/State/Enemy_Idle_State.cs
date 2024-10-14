using System.Collections;
using UnityEngine;

public class Enemy_Idle_State : EnemyState
{
    [SerializeField] private Pointer pointer;


    [SerializeField] private Transform target;


    public Enemy_Idle_State(Enemy enemy, EnemyStateMachine stateMachine, string animBoolHash) : base(enemy, stateMachine, animBoolHash)
    {

    }

    bool isSurveilling = false; // 감시가 진행 중인지 확인하는 변수

    public override void Enter()
    {
        Debug.Log("Follow Start");
    }
    private void Update()
    {
        if (!isSurveilling)
        {
           // StartCoroutine(Surveillance());
        }
    }

    IEnumerator Surveillance()
    {

        isSurveilling = true;

        for (int i = 1; i < pointer.points.Length; i++)
        {
            if (Enemy.transform.position != pointer.points[i])
            {
                Enemy.transform.position = Vector2.MoveTowards(Enemy.transform.position, target.position, 1);
            }
            yield return null;
        }

        yield return new WaitForSeconds(1f);
        isSurveilling = false;

        for (int i = 0; i < pointer.points.Length; i++)
        {

            Enemy.transform.position = Vector2.MoveTowards(Enemy.transform.position, pointer.points[i], Enemy.Speed);
            yield return new WaitForSeconds(1f);
            isSurveilling = false;

        }



    }
    public override void Exit()
    {
        Debug.Log("Follow End");
    }


}