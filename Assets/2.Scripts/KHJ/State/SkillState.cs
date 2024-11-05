using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillState : State
{
    [SerializeField] private DashPunch _dashPunchSkill;
    [SerializeField] private ElectorBulletSkill _electroBullet;


    protected override void EnterState()
    {
        if (_agent.SkillUICompo.CanSkill)
        {
            if (_agent.CompareTag("Player")) _dashPunchSkill.SkillPlay(_agent);
            else _electroBullet.SkillPlay(_agent);// 지금 내가 어떤 캐릭터를 해킹한 상태인지에 따라 (태그로 구분) 다른 스킬 사용
            _agent.SkillUICompo.Cool();
        }
                                    
        

        if (_agent.InputCompo.InputVector.magnitude > 0)  // 스킬 함수 호출해주고 바로 라이들/무브로 전환
        {
            _agent.TransitionState(_agent.StateCompo.GetState(StateType.Move));
        }
        else
        {
            _agent.TransitionState(_agent.StateCompo.GetState(StateType.Idle));
        }
    }


}
