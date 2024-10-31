using System.Collections;
using UnityEngine;

public class AttackState_SB : E_State
{

    private bool isDoing = false;

    private void Awake()
    {
        
    }
    protected override void EnterState()
    {
        _agent.AnimationCompo.PlayAnimaiton(AnimationType.attack);
    }
    public override void StateFixedUpdate()
    {
        StartCoroutine(Shoot());
    
    }
    public override void StateUpdate()
    {
        Rotattion(_agent.enemyData.target);
        Flip();
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
        
        if(!isDoing)
        {
            isDoing = true;
            print("ÆÎ");
        }
        yield return new WaitForSeconds(_agent.enemyData.attackDelay);
        isDoing = false;
 


    }
    
    protected override void Flip()
    {
        base.Flip();
    }

    protected override void Rotattion(GameObject target)
    {
        base.Rotattion(target);
    }
}