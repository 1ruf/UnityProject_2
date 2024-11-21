using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{
    public State _currentState { get; protected set; }
    public State _previousState { get; protected set; }
    [field: SerializeField] public virtual InputReader InputCompo { get; protected set; }


    public PlayerFlip FlipCompo;

    public NpcAnimation AnimCompo { get; protected set; }
    public Rigidbody2D RbCompo;
    protected SpriteRenderer _spriteRenderer;
    protected PlayerData _playerData;

    public StateFectory StateCompo { get; set; }
    private void Awake()
    {
        StateCompo = GetComponentInChildren<StateFectory>();
        RbCompo = GetComponent<Rigidbody2D>();
        AnimCompo = GetComponent<PlayerAnimaton>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _playerData = GetComponent<PlayerData>();
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
        FlipCompo.Flip(this);
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
