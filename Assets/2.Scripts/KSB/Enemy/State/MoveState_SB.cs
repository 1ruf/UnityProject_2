using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState_SB : E_State
{
    // Start is called before the first frame update
    protected override void EnterState()
    {
        _agent.AnimationCompo.PlayAnimaiton(AnimationType.run);
    }
    public override void StateFixedUpdate()
    {
      
    }

    public override void StateUpdate()
    {
        if (_agent.Hp <= 0)
        {
            _agent.TransitionState(_agent.DeathState);
        }
        if (_agent.Hp <= 0)
        {
            _agent.TransitionState(_agent.DeathState);
        }
        if (_agent.transform.position == _agent.point)
        {
            _agent.TransitionState(_agent.IdleState);
        }
       else if (_agent.transform.position != _agent.point)
            _agent.transform.position = Vector2.MoveTowards(_agent.transform.position, _agent.point, _agent._enemySO.speed * Time.deltaTime);
       
    }
}
