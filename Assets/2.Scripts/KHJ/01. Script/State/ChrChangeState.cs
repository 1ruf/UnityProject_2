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
                _characterChanged.ChangeCharacter(_npc, enemy); // ���ʹ̸� ã�Ƽ� ������Ʈ�� �Բ� ��ŷ �Լ� ȣ�� (ĳ���� ü����)
            } 
        }
       
        _npc.TransitionState(_npc.StateCompo.GetState(StateType.Idle));
    }
}
