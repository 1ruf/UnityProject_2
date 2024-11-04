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
            Console.WriteLine("¾ø½é");

        }
        else
        {
            Console.WriteLine("ÀÖÀ½");
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
        _agent.RbCompo.velocity = Vector3.zero;

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
        print("ÆÎ");
        Instantiate(_agent.enemyData.Bullet,_agent.enemyData.gunPos);
        yield return new WaitForSeconds(_agent.enemyData.attackDelay);
        isDoing = false;
    }






}