using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillState : State
{
    [SerializeField] private DashPunch _dashPunchSkill;
    [SerializeField] private ElectorBulletSkill _electroBullet;
    [SerializeField] private Bar _bar;

    protected override void EnterState()
    {
        if (_agent.SkillUICompo.CanSkill)
        {
            if (_agent.CompareTag("Player")) _dashPunchSkill.SkillPlay(_agent);
            else _electroBullet.SkillPlay(_agent);// ���� ���� � ĳ���͸� ��ŷ�� ���������� ���� (�±׷� ����) �ٸ� ��ų ���
            _bar.BarValueChange(-10);
            _agent.SkillUICompo.Cool();
        }
                                    
        

        if (_agent.InputCompo.InputVector.magnitude > 0)  // ��ų �Լ� ȣ�����ְ� �ٷ� ���̵�/����� ��ȯ
        {
            _agent.TransitionState(_agent.StateCompo.GetState(StateType.Move));
        }
        else
        {
            _agent.TransitionState(_agent.StateCompo.GetState(StateType.Idle));
        }
    }


}
