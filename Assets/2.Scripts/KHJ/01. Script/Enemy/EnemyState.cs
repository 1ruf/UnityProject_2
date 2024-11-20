using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    protected Enemy _enemy;



    public void InitializeState(Enemy enemy)
    {
        _enemy = enemy;
    }

    
    public virtual void StateFixedUpdate()
    {

    }

    public virtual void StateUpdate()
    {

    }

    protected virtual void EnterState()
    {

    }

    protected virtual void ExitState()
    {

    }


    public void Enter()
    {
        EnterState();
    }
    public void Exit()
    {
        ExitState();
    }
}
