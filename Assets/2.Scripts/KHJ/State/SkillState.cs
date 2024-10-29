using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillState : State
{
    [SerializeField] private DashPunch _dashPunchSkill;

    protected override void EnterState()
    {
        _dashPunchSkill.SkillPlay(_agent);
        if (_agent.InputCompo.InputVector.magnitude > 0)
        {
            _agent.TransitionState(_agent.StateCompo.GetState(StateType.Move));
        }
        else
        {
            _agent.TransitionState(_agent.StateCompo.GetState(StateType.Idle));
        }
    }


}
