using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillState : State
{
    [SerializeField] private DashPunchSkill _dashPunchSkill;

    protected override void EnterState()
    {
        _dashPunchSkill.SkillPlay(_agent);
        _agent.TransitionState(_agent.StateCompo.GetState(StateType.Idle));
    }


}
