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
    public override void StateUpdate()
    {
        _agent.enemyData.target = _agent.IdlePosition.gameObject;
        Debug.Log(_agent.IdlePosition.gameObject);

        if (_sensing.Detected)
        {
            _agent.TransitionState(_agent.GetState<FollowState_SB>());
        }
        else if (_agent.transform.position == _agent.point)
        {
            _agent.TransitionState(_agent.GetState<IdleState_SB>());
        }
       else if (_agent.transform.position != _agent.point)
            _agent.transform.position = Vector2.MoveTowards(_agent.transform.position, _agent.point, _agent.enemyData.speed * Time.deltaTime);
     
       
    }
}
