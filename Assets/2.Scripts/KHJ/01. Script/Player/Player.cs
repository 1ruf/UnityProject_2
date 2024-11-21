using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Npc
{
    [field : SerializeField] public InputReader InputCompo { get; protected set; }

    public PlayerStateFectory StateCompo { get; set; }
    public PlayerAnimaton AnimCompo { get; protected set; }
    protected PlayerData _playerData;

    private void Awake()
    {
        StateCompo = GetComponentInChildren<PlayerStateFectory>();
        AnimCompo = GetComponent<PlayerAnimaton>();
        _playerData = GetComponent<PlayerData>();
        RbCompo = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        TransitionState(StateCompo.GetState(StateType.Idle));
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
