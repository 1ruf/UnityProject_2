using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveFalse : MonoBehaviour
{
    [SerializeField] private KSB_Enemy _agent;
     [SerializeField] private Transform _Enemy;

    public void M_SetActiveFalse()
    {
        Destroy(_Enemy.gameObject);

    }
    public void TOPreviousState()
    {
        _agent.TransitionState(_agent.previousState);
    }
}
