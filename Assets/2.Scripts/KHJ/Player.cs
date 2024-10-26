using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public State _currentState {get; private set; }
    [SerializeField] public State _previousState { get; private set; }

    [field: SerializeField] public InputReader InputCompo { get; private set; }
    public Rigidbody2D RbCompo;


    public StateFectory StateCompo { get; set; }
    private void Awake()
    {
        StateCompo = GetComponentInChildren<StateFectory>();
        RbCompo = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        StateCompo.InitializeState(this);
        TransitionState(StateCompo.GetState(StateType.Idle));
    }

    private void FixedUpdate()
    {
        _currentState.StateFixedUpdate();
    }

    private void Update()
    {
        _currentState.StateUpdate();
    }

    internal void TransitionState(State desireState)
    {
        if (desireState == null) return;

        if (_currentState != null)
        {
            _currentState.Exit();
            _previousState = _currentState;
        }
        _currentState = desireState;
        _currentState.Enter();

    }



}
