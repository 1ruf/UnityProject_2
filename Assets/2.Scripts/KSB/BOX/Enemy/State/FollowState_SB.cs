using UnityEngine;

public class FollowState_SB : E_State
{
    protected override void EnterState()
    {
        _agent.AnimationCompo.PlayAnimaiton(AnimationType.run);
    }
    public override void StateUpdate()
    {

        if (!_sensing.Detected)
        {
            _agent.TransitionState(_agent.GetState<IdleState_SB>());
        }
        else if (_sensing.Attack)
        {
            _agent.TransitionState(_agent.GetState<AttackState_SB>());
        }
        
    }
    public override void StateFixedUpdate()
    {
        Follow();
    }
    private void Follow()
    {
        if (_agent.enemyData.target)
        {
            Vector2 targetPosition = _agent.enemyData.target.transform.position;
            Vector2 direction = (targetPosition - _agent.RbCompo.position).normalized; 
            
            _agent.RbCompo.velocity=(direction * _agent.enemyData.speed);
        }


    }

    protected override void ExitState()
    {
        _agent.RbCompo.velocity = Vector2.zero;
    }



}
