public class AttackState_SB : E_State
{
    protected override void EnterState()
    {
        _agent.AnimationCompo.PlayAnimaiton(AnimationType.attack);
    }
    public override void StateUpdate()
    {
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
    protected override void Flip()
    {
        base.Flip();
    }
}