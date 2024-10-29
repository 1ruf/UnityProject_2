using UnityEngine;

public class ChrChangeState : State
{
    [SerializeField] private CharacterChanged _characterChanged;
    protected override void EnterState()
    {
        print(1);

        RaycastHit2D ray = Physics2D.Raycast(_agent.InputCompo.MousePos, new Vector3(0,0,-10));
        if (ray)
        {
            KSB_Enemy enemy = ray.transform.GetComponent<KSB_Enemy>();
            if (enemy) _characterChanged.CharacterChange(_agent, enemy);
        }
       
        _agent.TransitionState(_agent.StateCompo.GetState(StateType.Idle));
    }
}
