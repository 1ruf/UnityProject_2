using UnityEngine;

public class ChrChangeState : State
{
    [SerializeField] private CharacterChanged _characterChanged;
    protected override void EnterState()
    {
        RaycastHit2D ray = Physics2D.Raycast(_agent.InputCompo.MousePos, new Vector3(0,0,-10));
        if (ray)
        {
            KSB_Enemy enemy = ray.transform.GetComponent<KSB_Enemy>();
            if (enemy)
            {
                _characterChanged.CharacterChange(_agent, enemy); // ���ʹ̸� ã�Ƽ� ������Ʈ�� �Բ� ��ŷ �Լ� ȣ�� (ĳ���� ü����)
                _agent.SkillUICompo.CoolTimeReSet(); //������ų �� �ʱ�ȭ
            } 
        }
       
        _agent.TransitionState(_agent.StateCompo.GetState(StateType.Idle));
    }
}
