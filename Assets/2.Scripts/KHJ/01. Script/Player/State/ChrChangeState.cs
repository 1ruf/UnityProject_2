using UnityEngine;

public class ChrChangeState : State
{
    [SerializeField] private CharacterChanged _characterChanged;
    protected override void EnterState()
    {
        print(1);
        RaycastHit2D ray = Physics2D.Raycast(_npc.InputCompo.MousePos, new Vector3(0,0,-10));
        if (ray)
        {
            Enemy enemy = ray.transform.GetComponent<Enemy>();
            if (enemy)
            {
                _characterChanged.ChangeCharacter(_npc, enemy); // 에너미를 찾아서 에이전트와 함께 해킹 함수 호출 (캐릭터 체인지)
            } 
        }
       
        _npc.TransitionState(_npc.StateCompo.GetState(StateType.Idle));
    }
}
