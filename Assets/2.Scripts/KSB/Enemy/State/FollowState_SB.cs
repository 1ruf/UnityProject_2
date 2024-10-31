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
        //Rotattion(_agent.enemyData.target);
    }
    private void Follow()
    {
        Flip();
        if (_agent.enemyData.target)
        {
            _agent.transform.position = Vector2.MoveTowards(_agent.transform.position,
               _agent.enemyData.target.transform.position, _agent.enemyData.speed * Time.deltaTime);
        }
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
