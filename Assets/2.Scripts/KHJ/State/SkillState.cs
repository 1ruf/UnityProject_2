using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillState : State
{
    [SerializeField] private DashPunch _dashPunchSkill;
    [SerializeField] private ElectorBulletSkill _electroBullet;
    [SerializeField] private Image _energybar;

    private Bar _bar;
    private int _skillCost = 10;
    private void Awake()
    {
        _bar = _energybar.GetComponentInParent<Bar>();
    }
    protected override void EnterState()
    {
        if (_agent.SkillUICompo.CanSkill)
        {
            if (CheckSkill())
            {
                if (_agent.CompareTag("Player")) _dashPunchSkill.SkillPlay(_agent);
                else _electroBullet.SkillPlay(_agent);// ���� ���� � ĳ���͸� ��ŷ�� ���������� ���� (�±׷� ����) �ٸ� ��ų ���
                _bar.BarValueChange(-_skillCost);
                _agent.SkillUICompo.Cool();
            }
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
    private bool CheckSkill()
    {
        float value = 0.2f;
        if (_energybar.fillAmount < value)
        {
            return false;
        }
        print(_energybar.fillAmount + "<-���� �뷮 , �ڽ�Ʈ ->" + value);
        return true;
    }

}
