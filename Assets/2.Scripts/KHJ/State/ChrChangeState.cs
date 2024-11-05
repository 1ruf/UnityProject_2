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
                _characterChanged.CharacterChange(_agent, enemy); // 에너미를 찾아서 에이전트와 함께 해킹 함수 호출 (캐릭터 체인지)
                _agent.SkillUICompo.CoolTimeReSet(); //고유스킬 쿨 초기화
            } 
        }
       
        _agent.TransitionState(_agent.StateCompo.GetState(StateType.Idle));
    }
}
