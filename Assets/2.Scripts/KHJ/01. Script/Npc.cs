using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{
    public State CurrentState { get; protected set; }
    public State PreviousState { get; protected set; }
    [field: SerializeField] public virtual InputReader InputCompo { get; protected set; }

    public virtual bool CanAttack { get; protected set; }


    public Flip FlipCompo;

    public NpcAnimation AnimCompo { get; protected set; }
    public Rigidbody2D RbCompo;
    protected SpriteRenderer _spriteRenderer;
    protected PlayerData _playerData;

    public StateFectory StateCompo { get; set; }
    private void Awake()
    {
        StateCompo = GetComponentInChildren<StateFectory>();
        RbCompo = GetComponent<Rigidbody2D>();
        AnimCompo = GetComponent<NpcAnimation>();
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
        CurrentState.StateFixedUpdate();
    }

    private void Update()
    {
        CurrentState.StateUpdate();
        FlipCompo.FlipNpc(this);
    }

    internal void TransitionState(State desireState)
    {
        if (desireState == null) return;

        if (CurrentState != null)
        {
            CurrentState.Exit();
            PreviousState = CurrentState;
        }
        CurrentState = desireState;
        CurrentState.Enter();
    }
}
