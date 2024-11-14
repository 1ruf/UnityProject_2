using UnityEngine;

public class Boss1_MoveState : BossState
{
    protected override void EnterState()
    {
        _boss.AniCompo.Boss_PlayAnimaton(Boss_AnimationType.Run);
    }

    public override void StateFixedUpdate()
    {
        base.StateFixedUpdate();
    }
    public override void StateUpdate()
    {
        float distance = (_boss.transform.position - _boss.point.point).magnitude;
        if (_boss.Detecting.isDetecting)
        {
            _boss.TransitionState(_boss.StateCompo.Boss_GetState(Boss_StateType.Run));
        }
        if (_boss.Detecting.startAttack)
        {
            _boss.TransitionState(_boss.StateCompo.Boss_GetState(Boss_StateType.Attack));
        }
        if (distance == 0)
        {
            _boss.TransitionState(_boss.StateCompo.Boss_GetState(Boss_StateType.Idle));
        }
        else if (_boss.transform.position != _boss.point.point)
            _boss.transform.position = Vector2.MoveTowards(_boss.transform.position, _boss.point.point, 3 * Time.deltaTime);
    }
}
