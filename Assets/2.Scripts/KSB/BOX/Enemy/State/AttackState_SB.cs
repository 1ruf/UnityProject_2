using System;
using System.Collections;
using UnityEngine;

public class AttackState_SB : E_State
{

    private bool isDoing = false;

    private void Start()
    {
        if (!_agent.enemyData.Bullet || !_agent.enemyData.gunPos)
        {
            Console.WriteLine("����");

        }
        else
        {
            Console.WriteLine("����");
        }
        
    }
    protected override void EnterState()
    {
        _agent.AnimationCompo.PlayAnimaiton(AnimationType.attack);
    }
    public override void StateFixedUpdate()
    {

        if (!isDoing)
        {
            StartCoroutine(Shoot());
        }
        else
        {
           _agent.RbCompo.velocity = Vector3.zero;
        }
      

    }
    public override void StateUpdate()
    {

        if (_sensing.Attack)
        {
            _agent.TransitionState(_agent.GetState<AttackState_SB>());
        }
        else if (_sensing.Detected)
        {
            _agent.TransitionState(_agent.GetState<FollowState_SB>());
        }
        else
        {
            _agent.TransitionState(_agent.GetState<MoveState_SB>());
        }


    }
    IEnumerator Shoot()
    {
        isDoing = true;
        print("��");
        Instantiate(_agent.enemyData.Bullet,_agent.enemyData.gunPos);
        _agent.RbCompo.AddForce(-transform.right*4.5f,ForceMode2D.Impulse);
        yield return new WaitForSeconds(_agent.enemyData.attackDelay);
        isDoing = false;
    }






}