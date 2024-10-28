using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChrChangeState : State
{
    [SerializeField] private CharacterChanged _characterChanged;
    protected override void EnterState()
    {
        RaycastHit2D ray = Physics2D.Raycast(_agent.InputCompo.MousePos, new Vector3(0,0,-10));
        if (!ray) return;
        _characterChanged.CharacterChange(_agent);
    }
}
