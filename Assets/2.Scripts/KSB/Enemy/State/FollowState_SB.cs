using UnityEngine;

public class FollowState_SB : E_State
{
   
    void Start()
    {

    }

    protected override void EnterState()
    {
      _agent.AnimationCompo.PlayAnimaiton(AnimationType.run);
    }
    public override void StateUpdate()
    {
        if (_agent._sensing.Attack)
        {
            _agent.TransitionState(_agent.AttackState);
        }
        if (!_agent._sensing.Attack)
            _agent.TransitionState(_agent.IdleState);
    }
    public override void StateFixedUpdate()
    {
        Follow();


    }
    private void Follow()
    {
        Flip();
        if(_agent.target)
        _agent.transform.position = Vector2.MoveTowards(_agent.transform.position, _agent.target.transform.position, _agent._enemySO.speed * Time.deltaTime);
      


    }

    protected override void Flip()
    {
        base.Flip();
    }

}
