using UnityEngine;

public class ChrChangeState : PlayerState
{
    [SerializeField] private CharacterChanged _characterChanged;
    protected override void EnterState()
    {
        print(1);
        RaycastHit2D ray = Physics2D.Raycast(_player.InputCompo.MousePos, new Vector3(0,0,-10));
        if (ray)
        {
            Enemy enemy = ray.transform.GetComponent<Enemy>();
            if (enemy)
            {
                _characterChanged.ChangeCharacter(_player, enemy); // ���ʹ̸� ã�Ƽ� ������Ʈ�� �Բ� ��ŷ �Լ� ȣ�� (ĳ���� ü����)
            } 
        }

        _player.TransitionState(_player.StateCompo.GetState(StateType.Idle));
    }
}
