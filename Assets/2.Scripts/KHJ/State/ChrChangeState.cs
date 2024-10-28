using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChrChangeState : State
{
    [SerializeField] private CharacterChanged _characterChanged;
    protected override void EnterState()
    {
        print(1);

        print("일단 들어옴 상태");
        RaycastHit2D ray = Physics2D.Raycast(_agent.InputCompo.MousePos, new Vector3(0,0,-10));
        if (ray)
        {
            print("레이 통과");
            KSB_Enemy enemy = ray.transform.GetComponent<KSB_Enemy>();
            if (enemy) _characterChanged.CharacterChange(_agent, enemy);
        }
       
        _agent.TransitionState(_agent.StateCompo.GetState(StateType.Idle));
    }
}
