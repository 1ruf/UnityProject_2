using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public State _currentState {get; private set; }
    public State _previousState { get; private set; }
    [field : SerializeField] public InputReader InputCompo { get; private set; }

    [SerializeField] public SkillUI SkillUICompo;

    [SerializeField] private PlayerFlip FlipCompo;

    public PlayerAnimaton AnimCompo { get; private set; }
    public Rigidbody2D RbCompo;
    private SpriteRenderer _spriteRenderer;
    private PlayerData _playerData;

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

    public void CharacterChangeed(/*enemySO enemyData*/) 
    {
        CreateDummy(_spriteRenderer.sprite, transform);


        /*AnimCompo = enemyData.Anim;
        _spriteRenderer.sprite = enemyData.sprite;
        _playerData.maxHealth = enemyData.maxHealth;
        _playerData.moveSpeed = enemyData.moveSpped;
        transform.position = enemyData.transform.position;
        transform.localScale = enemyData.transform.localScale;*/
        
    }

    private void CreateDummy(Sprite sprite, Transform trans)
    {
        
    }
}
