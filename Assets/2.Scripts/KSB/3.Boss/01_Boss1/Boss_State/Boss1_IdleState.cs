using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1_IdleState : BossState
{
    [SerializeField] private LayerMask _player;
    protected override void EnterState()
    {
        Debug.Log("1");
        _boss.AniCompo.Boss_PlayAnimaton(Boss_AnimationType.Idle);
        _boss.RbCompo.velocity =  Vector3.zero;
    }

    protected override void ExitState()
    {
        base.ExitState();
    }
    public override void StateFixedUpdate()
    {
        base.StateFixedUpdate();
    }

    public override void StateUpdate()
    {
        if (_boss.Detecting.isDetecting&&!_boss.Detecting.startAttack)
        {
            _boss.TransitionState(_boss.StateCompo.Boss_GetState(Boss_StateType.Run));//follow

        }   
        else if(_boss.Detecting.startAttack)
        {
            _boss.TransitionState(_boss.StateCompo.Boss_GetState(Boss_StateType.Attack));
        }

        if (_boss.health <= 0)
        {
            _boss.TransitionState(_boss.StateCompo.Boss_GetState(Boss_StateType.Death));
        }
    }


}
