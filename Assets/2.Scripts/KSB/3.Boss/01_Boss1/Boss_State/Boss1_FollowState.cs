using UnityEngine;

public class Boss1_FollowState : BossState
{

    protected override void EnterState()
    {
        _boss.AniCompo.Boss_PlayAnimaton(Boss_AnimationType.Run);
    }

    protected override void ExitState()
    {
        base.ExitState();
        _boss.RbCompo.velocity = Vector2.zero;
    }
    public override void StateFixedUpdate()
    {
        base.StateFixedUpdate();
    }

    public override void StateUpdate()
    {
        Follow();
        if (_boss.Detecting.startAttack)
        {
            _boss.TransitionState(_boss.StateCompo.Boss_GetState(Boss_StateType.Attack));
        }
        if (_boss.health <= 0 )
        {
            _boss.TransitionState(_boss.StateCompo.Boss_GetState(Boss_StateType.Death));
        }
        if(!_boss.Detecting.isDetecting)
        {
            _boss.TransitionState(_boss.StateCompo.Boss_GetState(Boss_StateType.Move));
        }
        
    }

    private void Follow()
    {
        GameObject target = _boss.Detecting.target;
        if (target != null)
        {
            Vector2 targetPosition = target.transform.position;
            Vector2 direction = (targetPosition - _boss.RbCompo.position).normalized;

            _boss.RbCompo.velocity = (direction * 3);//수정할겨
        }
     

    }
    private void Awake()
    {
        print(1);
    }
}
